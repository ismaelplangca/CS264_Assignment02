// Handles command logic to manipulate Canvas class
public sealed class CanvasRunner
{
    private static Canvas canvas = null!;
    public static void run()
    {
        bool run = true;
        var sf = new ShapeFactory();
        Console.WriteLine("CS264 Assignment 2\n20466014");
        Console.WriteLine("Use Default SVG Size [Yy/Nn]");
        while(canvas == null)
        {
            switch(Console.ReadLine() )
            {
                case "y" :
                case "Y" : canvas = new();
                    break;
                case "n" :
                case "N" : 
                    Console.WriteLine("Enter SVG Height And Width:\n[height] [width]");
                    var input = Console.ReadLine()!.Split(" ");
                    canvas = new(input[0],input[1]);
                    break;
                default : Console.WriteLine("Invalid command!");
                    break;
            }
        }
        Console.WriteLine();
        var commands =
            "Commands       :\n"
            + "Exit           : exit\n"
            + "Help           : help\n"
            + "List Shapes    : list (shows shape indexes)\n"
            + "Export SVG     : export [optional_name.svg]\n"
            + "Preview SVG    : preview\n"
            + "Edit Shape*    : edit [shape index]\n"
            + "Edit Style     : style [shape index]\n"
            + "Delete Shape   : delete [shape index]\n"
            + "Transform Shape: transform [shape index]\n"
            + "Change Z-Index : move [shape index] [top|bottom|shape index]\n"
            + "Group Shapes** : group [shape index] [shape index] [...]\n"
            + "Ungroup Shapes : ungroup [group index]\n"
            + "Syntax         : [shape] [variable1] [variable2] [variableN]\n"
            + "Examples       : rect 10 10 5 5\n"
            + "               : polyline 1,1 2,2 3,3\n"
            + "               : path M150 0 L75 200 L225 200 Z\n"
            + "Rectangle      : rect [X] [Y] [Height] [Width]\n"
            + "Circle         : circle [Cx] [Cy] [Radius]\n"
            + "Ellipse        : ellipse [Cx] [Cy] [Rx] [Ry]\n"
            + "Line           : line [X1] [Y1] [X2] [Y2]\n"
            + "Polyline       : polyline [X1,Y1] [X2,Y2] [X..,Y..] [XN,YN]\n"
            + "Polygon        : polygon [X1,Y2] [X2,Y2] [X..,Y..] [XN,YN]\n"
            + "Path           : path [Path Commands]\n"
            + "*ONLY ENTER SHAPE VARIABLES WHEN EDITING\n"
            + "**SHAPE INDEX ORDER DETERMINES GROUP ORDER\n"
            + "**SHAPES CANNOT BE EDITED WHILST IN GROUPS\n";
        Console.WriteLine(commands);

        Console.WriteLine("Start Drawing!");
        while(run)
        {
            Console.WriteLine("\nEnter Command:");
            var command = Console.ReadLine()!.Split(" ");
            try {
                switch(command[0])
                {
                    case "exit" : Console.WriteLine("\nGoodbye!"); run = false;
                        break;
                    case "help" : Console.WriteLine(commands);
                        break;
                    case "list" : Console.WriteLine("\n" + canvas.Contents() );
                        break;
                    case "export" :
                        try { canvas.ExportToSvg(command[1]);
                        } catch(IndexOutOfRangeException) {
                            canvas.ExportToSvg(DateTime.Now.ToString("hh-mm-ss tt") + ".svg");
                        }
                        Console.WriteLine("Canvas exported!");
                        break;
                    case "preview" : Console.WriteLine(canvas.ToSvgString() );
                        break;
                    case "edit" : EditShape(command[1]);
                        break;
                    case "style" : EditStyle(command[1]);
                        break;
                    case "delete" : DeleteShape(command[1]);
                        break;
                    case "transform" : EditTransform(command[1]);
                        break;
                    case "move" : MoveShape(command[1],command[2]);
                        break;
                    case "group" : canvas.GroupShapes(command.Skip(1).Select(x => int.Parse(x) ).ToArray() );
                        break;
                    case "ungroup" : canvas.UngroupShapes(int.Parse(command[1]) );
                        break;
                    case "rect" :
                    case "circle" :
                    case "ellipse" :
                    case "line" :
                    case "polyline" :
                    case "polygon" :
                    case "path" : canvas.AddShape(sf.CreateShape(command) );
                        break;
                    default : Console.WriteLine("Invalid Command!");
                        break;
                }
            } catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
    static void DeleteShape(string input)
    {
        canvas.RemoveShape(int.Parse(input) );
        Console.WriteLine("Shape deleted!");
    }
    static void EditShape(string input)
    {
        var shape = canvas.GetShape(int.Parse(input) );
        if(shape is Group)
        {
            Console.WriteLine("Groups have no coordinate values to be edited\nUse command style or transform instead");
            return;
        }
        Console.WriteLine("Editing: " + shape);
        Console.WriteLine("Enter New Values:");
        var changes = Console.ReadLine();
        shape.Edit(changes!);
        Console.WriteLine("\nNew Values: " + shape);
    }
    static void EditStyle(string input)
    {
        bool editrun = true;
        var shape = canvas.GetShape(int.Parse(input) );
        Console.WriteLine("\nEditing Style of " + shape);
        Console.WriteLine("\nCurrent Styles:");
        Console.WriteLine(shape.style.ShowStyles() + "\n");

        var editCommands = 
            "Edit Commands   :\n"
            + "Exit Editing    : exit\n"
            + "Help            : help\n"
            + "Add Property    : [property]\n"
            + "Remove Property : remove [property]\n"
            + "Edit Property   : [property] [value]";
        Console.WriteLine(editCommands);
        while(editrun)
        {
            Console.WriteLine("\nEnter Edit Command:");
            var command = Console.ReadLine()!.Split(" ");
            switch(command[0])
            {
                case "exit" : editrun = false;
                    break;
                case "help" : Console.WriteLine(editCommands);
                    break;
                case "remove" :
                    try { shape.style.RemoveStyle(command[0]);
                    } catch(Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine("\n" + shape.style.ShowStyles() );
                    break;
                default :
                    try { 
                        shape.style
                        .EditProperty(
                            command[0],
                            command.Skip(1).Aggregate((x,y) => x + " " + y)
                        );
                    } catch(Exception) {
                        shape.style.EditProperty(command[0],"");
                    }
                    Console.WriteLine("\n" + shape.style.ShowStyles() );
                    break;
            }
        }
        Console.WriteLine("\nExiting Style Editing");
    }
    static void EditTransform(string input)
    {
        bool run = true;
        var shape = canvas.GetShape(int.Parse(input) );
        Console.WriteLine("\nEditing Transforms of " + shape);
        Console.WriteLine("\nCurrent Translations:");
        Console.WriteLine(shape.transforms.ShowTransforms() + "\n");

        var editCommands = 
            "Edit Commands  :\n"
            + "Exit Editing   : exit\n"
            + "Help           : help\n"
            + "Edit Transform : [transform] [value]";
        Console.WriteLine(editCommands);
        while(run)
        {
            Console.WriteLine("\nEnter Edit Command:");
            try {
                var command = Console.ReadLine()!.Split(" ");
                switch(command[0])
                {
                    case "exit" : run = false;
                        break;
                    case "help" : Console.WriteLine(editCommands);
                        break;
                    default :
                        shape.transforms
                        .EditTranslation(
                            command[0],
                            command.Skip(1).Aggregate((x, y) => x + " " + y)
                        );
                        Console.WriteLine("\n" + shape.transforms.ShowTransforms() );
                        break;
                }
            } catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
        Console.WriteLine("\nExiting Style Editing");
    }
    static void MoveShape(string s1Index, string s2Index)
    {
        int i1 = int.Parse(s1Index);
        int i2 = 0;
        switch(s2Index)
        {
            case "top" : canvas.SwapShape(i1, 0);
                return;
            case "bottom" : canvas.SwapShape(i1, canvas.ShapeCount() - 1);
                return;
            default : i2 = int.Parse(s2Index);
                break;
        }
        canvas.SwapShape(i1,i2);
    }
}