using System.Diagnostics;

TimeSpan startTime = new TimeSpan(0,0,0);
run(startTime);

TimeSpan adder(string inp, char sign) {
    int inpNum = int.Parse(inp);
    TimeSpan addTime = TimeSpan.FromSeconds(inpNum);
    if (sign == '-') return -addTime;
    else return addTime;
}

TimeSpan run(TimeSpan initTime) {
    var sw = new Stopwatch();
    sw.Start();
    TimeSpan ts = new TimeSpan(0,0,0);
    ConsoleKeyInfo key = new ConsoleKeyInfo();
    while(true) {
        if (Console.KeyAvailable) {
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape){
                sw.Stop();
                break;
            }
            else if (key.Key == ConsoleKey.Spacebar){
                Console.WriteLine("\nWas pressed " + key.Key);
                ts = sw.Elapsed + initTime - (new TimeSpan(0,0,1));
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Spacebar) {
                    run(ts);
                    break;
                }
            }
            else if (key.Key == ConsoleKey.Z) {
                Console.Write("\b ");
                Console.WriteLine("\nWas pressed " + key.Key);
                run(new TimeSpan(0,0,0));
                break;
            }
            else if ((key.Key == ConsoleKey.H) | (key.Key == ConsoleKey.F1)){
                Console.Write("\b ");
                Console.WriteLine("\nWas pressed " + key.Key);
                ts = sw.Elapsed + initTime - (new TimeSpan(0,0,1));
                Console.WriteLine("Press Spacebar for continue\n" +
                                  "Esc for exit\n" +
                                  "Z for zeroing");
                key = Console.ReadKey();
                if ((key.Key == ConsoleKey.Spacebar) | (key.Key == ConsoleKey.Enter)){
                    run(ts);
                    break;
                }
            }
            else if (key.Key == ConsoleKey.C) {
                Console.Write("\b ");
                Console.WriteLine("\nWas pressed " + key.Key);
                ts = sw.Elapsed + initTime - (new TimeSpan(0,0,1));
                String inp = Console.ReadLine();
                if (inp[0] == '-') ts += adder(inp[1..], '-');
                else if (inp[0] == '+') ts += adder(inp[1..], '+');
                else ts += adder(inp, ' ');
                run(ts);
                break;
            }
            else{
                Console.Write("\b ");
            }
        }
        ts = sw.Elapsed + initTime;
        Console.Write($"\r{ts.Hours}h {ts.Minutes}m {ts.Seconds}s");
        Thread.Sleep(1000);
    }
    sw.Stop();
    return ts;
}
