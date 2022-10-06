namespace TaskProject
{
    class Args
    {
        public int a;
        public int b;
    }
    internal class Program
    {
        static int TaskSum(object obj)
        {
            Args args = (Args)obj;
            Console.WriteLine($"Task Sum. Result = {args.a + args.b}");
            return args.a + args.b;
        }



        static int SumGauss(object obj)
        {
            int n = (int)obj;
            int result = 0;
            for (int i = 1; i <= n; i++)
                result += i;
            return result;
        }

        static int SumGaussFor(int n)
        {
            int result = 0;
            for (int i = 1; i <= n; i++)
                result += i;
            return result;
        }

        static void SumGaussAction(int n)
        {
            int result = 0;
            for (int i = 1; i <= n; i++)
                result += i;
            Thread.Sleep(1000);
            Console.WriteLine($"sum to {n} = {result}");
        }

        static void SumGaussActionBreak(int n, ParallelLoopState state)
        {
            if (n == 13)
                state.Break();

            int result = 0;
            for (int i = 1; i <= n; i++)
                result += i;
            Thread.Sleep(1000);
            Console.WriteLine($"sum to {n} = {result}");
        }

        static void PrintTask(Task task)
        {
            Console.WriteLine($"Task Second - {Task.CurrentId}");
            Console.WriteLine($"Task Input - {task.Id}");
        }
        static void Main(string[] args)
        {
            // 1
            //Task task1 = new Task(() => 
            //{ 
            //    Console.WriteLine($"Simple Start {Thread.CurrentThread.ManagedThreadId}");
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"Simple Finish {Thread.CurrentThread.ManagedThreadId}");
            //});
            //task1.Start();

            // 2
            //Task task2 = Task.Factory.StartNew(() => Console.WriteLine($"Factory Start {Thread.CurrentThread.ManagedThreadId}"));

            // 3
            //Task task3 = Task.Run(() => Console.WriteLine($"Run method Start {Thread.CurrentThread.ManagedThreadId}"));

            //Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId}");

            //Console.WriteLine($"task {task1.Id}");
            //Console.WriteLine($"task {task1.IsCompleted}");
            //Console.WriteLine($"task {task1.IsCompletedSuccessfully}");
            //Console.WriteLine($"task {task1.Status}");

            //task1.Wait();
            ////task2.Wait();
            ////task3.Wait();
            //Console.WriteLine($"------------------------");
            //Console.WriteLine($"task {task1.IsCompleted}");
            //Console.WriteLine($"task {task1.IsCompletedSuccessfully}");
            //Console.WriteLine($"task {task1.Status}");


            // INNERS TASK

            //Task taskOut = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine($"Outer task is Start");
            //    Task taskIn = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine($"Inner task is Start");
            //        Task taskInIn = Task.Factory.StartNew(() =>
            //        {
            //            Console.WriteLine($"Inner inner task is Start");
            //            Thread.Sleep(2000);
            //            Console.WriteLine($"Inner inner task is Finish");
            //        }, TaskCreationOptions.AttachedToParent);

            //        Thread.Sleep(1000);
            //        Console.WriteLine($"Inner task is Finish");
            //    }, TaskCreationOptions.AttachedToParent);



            //    Console.WriteLine($"Outer task is Finish");
            //});

            //taskOut.Wait();
            //Console.WriteLine($"Main thread");

            // TASK WAITALL
            //Task[] tasks = new Task[10];
            //int j = 1;
            //for (int i = 0; i < tasks.Length; i++)
            //{
            //    tasks[i] = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine($"Task {j++} in Thread {Thread.CurrentThread.ManagedThreadId} is work");
            //        Thread.Sleep(1000);
            //    });
            //}
            //Console.WriteLine($"Main thread");
            //Task.WaitAll(tasks);


            // Task<TResult>
            //int a = 10, b = 20;

            //Task<int> taskSum = new Task<int>(() => a + b);
            //taskSum.Start();
            //Console.WriteLine(taskSum.Result);

            //Task<int> taskGauss = Task.Factory.StartNew((obj) =>
            //{
            //    int n = (int)obj;
            //    int result = 0;
            //    for (int i = 1; i <= n; i++)
            //        result += i;
            //    return result;
            //}, 1000);
            //Task<int> taskGauss = Task.Factory.StartNew(SumGauss, 1000);

            //Console.WriteLine(taskGauss.Result);


            // Continuation Tasks
            //Task task1 = new Task(() =>
            //{
            //    Console.WriteLine($"Task First - {Task.CurrentId}");
            //});

            //Task task2 = task1.ContinueWith(PrintTask);

            //task1.Start();

            //task2.Wait();

            // Chain with result
            //Task<int> taskSum = new Task<int>(() => 10 + 20);
            //Task taskPrint = taskSum.ContinueWith(task =>
            //{
            //    Console.WriteLine(task.Result);
            //});
            //taskSum.Start();
            //taskPrint.Wait();


            // Chain with result 3 task
            //Task<int> taskSum = new Task<int>(TaskSum, new Args{ a = 4, b = 6 });
            //Task<int> taskSqr = taskSum.ContinueWith(task =>
            //{
            //    Console.WriteLine($"Task Sqr. Result = {(int)Math.Pow(task.Result, 2)}");
            //    return (int)Math.Pow(task.Result, 2);
            //});
            //Task<int> taskGauss = taskSqr.ContinueWith(task =>
            //{
            //    int sum = 0;
            //    for (int i = 0; i <= task.Result; i++)
            //        sum += i;

            //    Console.WriteLine($"Task Gauss. Result = {sum}");
            //    return sum;
            //});

            //taskSum.Start();
            //taskGauss.Wait();

            //Console.WriteLine($"{taskGauss.Result}");

            //Random random = new Random();

            //Parallel.Invoke(
            //    () =>
            //    {
            //        for (int i = 0; i < 10; i++)
            //        {
            //            Console.WriteLine($"Action 1 {i + 1}");
            //            Thread.Sleep(random.Next(500, 1000));
            //        }

            //    },
            //    () =>
            //    {
            //        for (int i = 0; i < 10; i++)
            //        {
            //            Console.WriteLine($"Action 2 {i + 1}");
            //            Thread.Sleep(random.Next(500, 1000));
            //        }
            //    },
            //    () =>
            //    {
            //        for (int i = 0; i < 10; i++)
            //        {
            //            Console.WriteLine($"Action 3 {i + 1}");
            //            Thread.Sleep(random.Next(500, 1000));
            //        }

            //    });


            //Parallel FOR
            //for(int i = 10; i <= 20; i++)
            //    SumGaussAction(i);

            //Console.WriteLine("------");

            //Parallel.For(10, 21, SumGaussAction);

            //Console.WriteLine($"Main Thread");

            // Parallel FOREACH
            Random random = new Random();
            List<int> numRand = new List<int>();
            for(int i = 0; i < 10; i++)
            {
                int size = random.Next(10, 21);
                numRand.Add(size);
                Console.Write($"{size} ");
            }
            Console.WriteLine();
            Console.WriteLine();


            ParallelLoopResult result = Parallel.ForEach(numRand, SumGaussActionBreak);
            if (!result.IsCompleted)
                Console.WriteLine($"Break parallel loop on {result.LowestBreakIteration}");

        }
    }
}