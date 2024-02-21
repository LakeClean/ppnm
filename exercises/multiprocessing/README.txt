

1.)


2.)

The "System.Threading.Tasks.Parallel.For( 1, N+1, (int i) => sum+=1.0/i );" runs slower than the self made method and it seems 
to return the wrong value. This is because the parameter "sum" can only be accessed once at a time and so even though
we are spreading out the work load over different processors, only one of these are working at a time. Also due to how the doubles work,
meaning how precise they are, means that if you add a small double to a large one, the small one is not represented proberly. Since
each processor accesses the sum in a seemingly random order we will have exactly the issue with doubles as described happen. 
We therefore always get a too low estimate. 

The method using "System.Linq" does find the right result, but it does so much slower than our own defined method. This is likely
due to the fact that the time to do the operations defined by us, i.e. a multiplication and a sum, is much faster than calling
a function (.Value) for every term, even though the operation in the function might be very simple in itself. 
