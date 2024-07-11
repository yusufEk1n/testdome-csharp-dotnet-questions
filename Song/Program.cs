/*
    >>> if song list is repeats at any point, it is a repeating playlist.
    
    >>> Example:
    ________      ________      ________
    |      |      |      |      |      |
    |  s1  |  →   |  s2  |  →   |  s3  |
    |______|      |______|      |______|
        ↑                           |
        |___________________________|
*/

using System;
using System.Collections.Generic;

public class Song
{
    private string name;
    public Song NextSong { get; set; }
 
    public Song(string name)
    {
        this.name = name;
    }
    
    public bool IsInRepeatingPlaylist()
    {
        HashSet<string> songNamesInPlaylist = new HashSet<string>();
        var currentSong = this;

        while(true)
        {
            if(currentSong.NextSong == null)
            {
                return false;
            }
            
            if(songNamesInPlaylist.Contains(currentSong.name))
            {
                return true;
            }
            else
            {
                songNamesInPlaylist.Add(currentSong.name);
                currentSong = currentSong.NextSong;
            }
        }
    }
    
    public static void Main(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Eye of the tiger");

        first.NextSong = second;
        second.NextSong = first;
        
        Console.WriteLine(first.IsInRepeatingPlaylist());
    }
}