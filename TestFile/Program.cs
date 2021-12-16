using System;
using System.Text.Json;
using FreeBusy.Data;

DateTime start = new DateTime(2009, 12, 10, 10, 0, 0); 
DateTime end = new DateTime(2009, 12, 10, 10, 30, 0);
DateTime meeting = new DateTime(2009, 12, 10, 10, 31, 0);

if (meeting < start)
{
    Console.WriteLine(meeting);
}
else if (meeting > end)
{

}


//var data = new DBCore();
//var date = "3/13/2015 08:00:00 AM";
//var avi = data.AvilablEmployees(DateTime.Parse(date), 3);
//var bla = JsonSerializer.Serialize(avi);
//Console.Write(bla);
//Console.Read();