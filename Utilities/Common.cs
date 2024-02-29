using System.Text.RegularExpressions;
using Utilities.Models;

namespace Utilities;

public static class Common
{
    private static readonly Random random = new();
    public static string EncodeToBase64(string message)
    {
        try
        {
            byte[] encData_byte = new byte[message.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(message);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }
    }

    public static string DecodeFrom64(string encodedData)
    {
        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        System.Text.Decoder utf8Decode = encoder.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(encodedData);
        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        string result = new(decoded_char);
        return result;
    }
    public static string GetUniqId()
    {
        Guid myuuid = Guid.NewGuid();
        return myuuid.ToString();
    }
    public static int GetRandomInteger(int low, int high)
    {
        return random.Next(low, high);
    }
    public static Double GetRandomDouble()
    {
        double num = random.NextDouble();
        return num;
    }
    public static Double GetRandomDouble(int low, int high)
    {
        int i = GetRandomInteger(low, high);
        double num = random.NextDouble();
        num = i + num;
        return num;
    }
    public static T DeserializeToObject<T>(string filepath) where T : class
    {
        System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

        using (StreamReader sr = new StreamReader(filepath))
        {
            return (T)ser.Deserialize(sr);
        }
    }
    public static string GetRandomColor()
    {
        Random rnd = new();
        string hexOutput = String.Format("{0:X}", rnd.Next(0, 0xFFFFFF));
        while (hexOutput.Length < 6)
            hexOutput = "0" + hexOutput;
        return "#" + hexOutput;
    }

    public static List<Country> GetCountryListOfLength(int len, int low, int high)
    {
        string[] countryArray = ["Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Anguilla", "Antigua & Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia & Herzegovina", "Botswana", "Brazil", "British Virgin Islands", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Cape Verde", "Cayman Islands", "Chad", "Chile", "China", "Colombia", "Congo", "Cook Islands", "Costa Rica", "Cote D Ivoire", "Croatia", "Cruise Ship", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Estonia", "Ethiopia", "Falkland Islands", "Faroe Islands", "Fiji", "Finland", "France", "French Polynesia", "French West Indies", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guam", "Guatemala", "Guernsey", "Guinea", "Guinea Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Isle of Man", "Israel", "Italy", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kuwait", "Kyrgyz Republic", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Mauritania", "Mauritius", "Mexico", "Moldova", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Namibia", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Norway", "Oman", "Pakistan", "Palestine", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russia", "Rwanda", "Saint Pierre & Miquelon", "Samoa", "San Marino", "Satellite", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "South Africa", "South Korea", "Spain", "Sri Lanka", "St Kitts & Nevis", "St Lucia", "St Vincent", "St. Lucia", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor L'Este", "Togo", "Tonga", "Trinidad & Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks & Caicos", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "Uruguay", "Uzbekistan", "Venezuela", "Vietnam", "Virgin Islands (US)", "Yemen", "Zambia", "Zimbabwe"];

        List<Country> countries = [];
        if (len >= countryArray.Length)
        {
            len = countryArray.Length;
        }
        for (int j = 0; j < len; j++)
        {
            var country = new Country
            {
                Name = countryArray[j],
                Color = GetRandomColor(),
                Value = GetRandomDouble(low, high)
            };
            countries.Add(country);
        }
        return countries;
    }
    public static bool ContainsWhitespace(string str) => str.Any(x => Char.IsWhiteSpace(x));

    public static bool IsAlphaNumeric(string str) => Regex.IsMatch(str, "^[a-zA-Z0-9]*$");
}
