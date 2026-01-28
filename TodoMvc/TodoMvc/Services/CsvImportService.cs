using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using TodoMvc.Models;
using TodoMvc.Models.Csv;

namespace TodoMvc.Services
{
    /// Read csv stream and converts row into TodoItem objects.

    public class CsvImportService
    {
        public CsvImportResult ImportTodos(Stream csvStream)
        {
            var result = new CsvImportResult();

            using var reader = new StreamReader(csvStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            // Make csv import more leanient for my demos
            csv.Context.Configuration.TrimOptions = CsvHelper.Configuration.TrimOptions.Trim;
            csv.Context.Configuration.BadDataFound = null;
            csv.Context.Configuration.MissingFieldFound = null;
            csv.Context.Configuration.HeaderValidated = null;

            List<TodoCsvRow> rows;
            try
            {
                rows = csv.GetRecords<TodoCsvRow>().ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add($"CSV read failed: {ex.Message}");
                return result;
            }

            for (int i = 0; i < rows.Count; i++)
            {
                var rowNumber = i + 2; // +2 because row 1 is header
                var row = rows[i];

                var title = (row.Title ?? string.Empty).Trim();
                if (string.IsNullOrWhiteSpace(title))
                {
                    result.Errors.Add($"Row {rowNumber}: Title is required.");
                    continue;
                }

                DateTime? dueDate = null;
                var dueDateRaw = (row.DueDate ?? string.Empty).Trim();

                if (!string.IsNullOrWhiteSpace(dueDateRaw))
                {
                    if (DateTime.TryParseExact(dueDateRaw, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out var parsedExact))
                    {
                        dueDate = parsedExact.Date;
                    }
                    else if (DateTime.TryParse(dueDateRaw, CultureInfo.InvariantCulture,
                            DateTimeStyles.AssumeLocal, out var parsed))
                    {
                        dueDate = parsed.Date;
                    }
                    else
                    {
                        result.Errors.Add($"Row {rowNumber}: DueDate '{dueDateRaw}' is not a valid date.");
                    }
                }

                result.Items.Add(new TodoItem
                {
                    Title = title,
                    DueDate = dueDate,
                    IsDone = false
                });
            }

            return result;
        }
    }

    /// Result object so the controller can show successful + row errors cleanly.
    public class CsvImportResult
    {
        public List<TodoItem> Items { get; } = new();
        public List<string> Errors { get; } = new();
        public bool HasErrors => Errors.Count > 0;
    }
}
