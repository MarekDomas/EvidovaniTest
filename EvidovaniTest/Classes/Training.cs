using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace EvidovaniTest.Classes;

public class Training
{
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public List<Exercise> Exercizes { get; set; }
    public string? Description { get; set; }
}