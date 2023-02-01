using System.Diagnostics;

TimeSpan startTime = new TimeSpan(0,0,0);
run(startTime);

TimeSpan run(TimeSpan initTime) {
    var sw = new Stopwatch();
    sw.Start();
    TimeSpan ts = new TimeSpan(0,0,0);
    ConsoleKeyInfo key = new ConsoleKeyInfo();
    while(true) {
        if (Console.KeyAvailable) {
            key = Console.ReadKey(true);
            Console.WriteLine("\nWas pressed " + key.Key);

            if (key.Key == ConsoleKey.Escape) {
                sw.Stop();
                break;
            }
            else if (key.Key == ConsoleKey.Spacebar) {
                Console.WriteLine("Press Spacebar for continue\n" +
                "Esc for exit\n" +
                "Z for zeroing");
                ts = sw.Elapsed + initTime;
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Spacebar) {
                    run(ts);
                    break;
                }
                else if (key.Key == ConsoleKey.Z) {
                    run(new TimeSpan(0,0,0));
                    break;
                }
            }
        }
        Thread.Sleep(1000);
        ts = sw.Elapsed + initTime;
        Console.Write($"\r{ts.Hours}h {ts.Minutes}m {ts.Seconds}s");
    }
    sw.Stop();
    return ts;
}