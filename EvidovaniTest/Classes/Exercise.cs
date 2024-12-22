using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidovaniTest.Classes;

public class Exercise
{
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    string[] cviky =
    [
        "Bench press",             
        "Dřepy",                   
        "Mrtvý tah",               
        "Shyby",                   
        "Stahování kladky",        
        "Tlaky nad hlavou",        
        "Bicepsové zdvihy",        
        "Kliky na bradlech",       
        "Leg press",               
        "Prkno (plank)",           
        "Sedy-lehy",               
        "Výpony na lýtka",         
        "Přítahy činky v předklonu"
    ];
}