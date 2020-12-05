using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode_2020.Day04
{
    public static class ExtensionMethods
    {
        public static readonly string[] EyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        public static int CountValidPassportsNaively(this IList<string> input)
        {
            return input
                .ToSingleLinePassportData()
                .Select(data => data.HasRequiredFields())
                .Count(valid => valid);
        }

        public static int CountValidPassportsProperly(this IList<string> input)
        {
            return input
                .ToSingleLinePassportData()
                .Where(data => data.HasRequiredFields())
                .Select(data => data.ToDataFields())
                .Count(dataFields => dataFields.HasValidFields());
        }

        private static bool HasRequiredFields(this string input)
        {
            var data = input.Split(' ');

            if (data.Length < 7)
            {
                return false;
            }

            if (data.Length == 8)
            {
                return true;
            }

            return data.Count(item => item.StartsWith("cid:")) == 0;
        }

        private static bool HasValidFields(this Dictionary<string, string> fields)
        {
            return fields.All(field => field.Key switch
                {
                    "byr" => field.Value.IsValidBirthYear(),
                    "iyr" => field.Value.IsValidIssueYear(),
                    "eyr" => field.Value.IsValidExpirationYear(),
                    "hgt" => field.Value.IsValidHeight(),
                    "hcl" => field.Value.IsValidHairColor(),
                    "ecl" => field.Value.IsValidEyeColor(),
                    "pid" => field.Value.IsValidPassportId(),
                    "cid" => true,
                    _ => false
                }
            );
        }

        private static bool IsValidBirthYear(this string data)
        {
            var isInteger = int.TryParse(data, out var year);
            return isInteger && 1920 <= year && year <= 2002;
        }

        private static bool IsValidExpirationYear(this string data)
        {
            var isInteger = int.TryParse(data, out var year);
            return isInteger && 2020 <= year && year <= 2030;
        }

        private static bool IsValidEyeColor(this string data)
        {
            return EyeColors.Contains(data);
        }

        private static bool IsValidHairColor(this string data)
        {
            return Regex.IsMatch(data, @"^#([a-fA-F0-9]{6})$");
        }

        private static bool IsValidHeight(this string data)
        {
            var matches = Regex.Match(data, @"^(\d+)(\w{2})$");

            if (!matches.Success)
            {
                return false;
            }

            var isInteger = int.TryParse(matches.Groups[1].Value, out var height);
            var unit = matches.Groups[2].Value;

            return unit switch
            {
                "cm" => isInteger && 150 <= height && height <= 193,
                "in" => isInteger && 59 <= height && height <= 76,
                _ => false,
            };
        }

        private static bool IsValidIssueYear(this string data)
        {
            var isInteger = int.TryParse(data, out var year);
            return isInteger && 2010 <= year && year <= 2020;
        }

        private static bool IsValidPassportId(this string data)
        {
            return Regex.IsMatch(data, @"^\d{9}$");
        }

        private static Dictionary<string, string> ToDataFields(this string line)
        {
            return line
                .Split(' ')
                .ToDictionary(
                    item => item.Split(':').First(),
                    item => item.Split(':').Last()
                );
        }

        private static IList<string> ToSingleLinePassportData(this IList<string> input)
        {
            return string
                .Join('\n', input)
                .Split("\n\n")
                .Select(line => line.Replace('\n', ' '))
                .ToList();
        }
    }
}