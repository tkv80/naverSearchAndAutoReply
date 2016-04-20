namespace NaverSearch
{
    public static class Util
    {
        public static string Substring(this string html, string startString, string endStrng)
        {
            return
                html.Substring(html.IndexOf(startString, System.StringComparison.Ordinal) + startString.Length,
                    html.IndexOf(endStrng, html.IndexOf(startString, System.StringComparison.Ordinal),
                        System.StringComparison.Ordinal) - html.IndexOf(startString, System.StringComparison.Ordinal) -
                    startString.Length).Trim();
        }
    }
}
