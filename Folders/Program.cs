/*
    other solution using regex.
    this solution passes the tests but not a good solution. It is error prone.
    
    "
    List<string> folderNames = new List<string>();
    var matches = Regex.Matches(xml, "\"(.*?)\"");
    foreach(Match match in matches)
    {
        var name = match.Groups[1].Value;

        if(name.StartsWith(startingLetter)) folderNames.Add(name);
    }

    return folderNames;
    "

*/


using System.Xml.Linq;

public class Folders
{
    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        List<string> folderNames = new List<string>();  

        var xmlFormat = XDocument.Parse(xml);
        var folders = xmlFormat.Descendants("folder"); //get all folder elements

        foreach(var folder in folders)
        {
            var name = folder.Attribute("name").Value; // get the name attribute value
            if(name.StartsWith(startingLetter)) folderNames.Add(name);
        }

        return folderNames;
    }

    public static void Main(string[] args)
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

        foreach (string name in Folders.FolderNames(xml, 'u'))
            Console.WriteLine(name);
    }
}