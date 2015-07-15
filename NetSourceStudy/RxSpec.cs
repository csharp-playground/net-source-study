using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;

namespace NetSourceStudy
{
    public class RxSpec
    {

        [Test]
        public void ObservingAGenericIEnumerable() {
            IEnumerable<int> someInts = new List<int> { 1, 2, 3, 4, 5 };

            // To convert a generic IEnumerable into an IObservable, use the ToObservable extension method.
            IObservable<int> observable = someInts.ToObservable();
        }

        [Test]
        public void CombineLatestParallelExecution()
        {
            var o = Observable.CombineLatest( 
                Observable.Start(() => { Console.WriteLine("Executing 1st on Thread: {0}", Thread.CurrentThread.ManagedThreadId); return "Result A"; }), 
                Observable.Start(() => { Console.WriteLine("Executing 2nd on Thread: {0}", Thread.CurrentThread.ManagedThreadId); return "Result B"; }), 
                Observable.Start(() => { Console.WriteLine("Executing 3rd on Thread: {0}", Thread.CurrentThread.ManagedThreadId); return "Result C"; })
                ) .Finally(() => Console.WriteLine("Done!")); 

            foreach (string r in o.First())
                Console.WriteLine(r);
        }

        [Test]
        public async void RunCodeAsynchronously()
        {
            Console.WriteLine("Shows use of Start to start on a background thread:");
            Console.WriteLine("Main Thread {0}", Thread.CurrentThread.ManagedThreadId);
            var o = Observable.Start(() =>
            {
                //This starts on a background thread.
                Console.WriteLine("From background thread. Does not block main thread.");
                Console.WriteLine("Calculating...");
                Thread.Sleep(1000);
                Console.WriteLine("Background work completed.");
                Console.WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
            });
            await o.FirstAsync();   // subscribe and wait for completion of background operation.  If you remove await, the main thread will complete first.
            Console.WriteLine("Main thread completed.");
        }
    }
}
