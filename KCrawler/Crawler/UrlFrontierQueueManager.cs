using System.Collections.Generic;

namespace KCrawler
{
   [System.Serializable]
    public class UrlFrontierQueueManager
    {
        
        Queue<string> lowQueue = new Queue<string>();
        Queue<string> belowQueue = new Queue<string>();
        Queue<string> normalQueue = new Queue<string>();
        Queue<string> aboveQueue = new Queue<string>();
        Queue<string> highQueue = new Queue<string>();

        public int Count
        {
            get
            {
                int count = 0;
                lock (this)
                {
                    count = lowQueue.Count + belowQueue.Count + normalQueue.Count + aboveQueue.Count + highQueue.Count;
                }
                return count;
            }
           
        }

       public string QueueTotal
        {
            get
            {
                
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
    
                sb.Append(R.Level_5).Append(highQueue.Count);

                sb.Append(" " + R.Level_4).Append(aboveQueue.Count);

                sb.Append(" " + R.Level_3).Append(normalQueue.Count);

                sb.Append(" " + R.Level_2).Append(belowQueue.Count);

                sb.Append(" " + R.Level_1).Append(lowQueue.Count);

                return sb.ToString();
            }
        }

        public void Clear()
        {
            lock (this)
            {
                lowQueue.Clear();
                belowQueue.Clear();
                normalQueue.Clear();
                aboveQueue.Clear();
                highQueue.Clear();
            }
        }

        public void Enqueue(string url)
        {
            lock (this)
            {
                normalQueue.Enqueue(url);
            }
        }


        public void Enqueue(string url, FrontierQueuePriority priority)
        {
            lock (this)
            {
                switch (priority)
                {
                    case FrontierQueuePriority.Low:
                        lowQueue.Enqueue(url);
                        break;
                    case FrontierQueuePriority.BelowNormal:
                        belowQueue.Enqueue(url);
                        break;
                    case FrontierQueuePriority.Normal:
                        normalQueue.Enqueue(url);
                        break;
                    case FrontierQueuePriority.AboveNormal:
                        aboveQueue.Enqueue(url);
                        break;
                    case FrontierQueuePriority.High:
                        highQueue.Enqueue(url);
                        break;
                    default:
                        normalQueue.Enqueue(url);
                        break;
                }
            }
            
        }

        public string Dequeue()
        {
            lock (this)
            {
                if (highQueue.Count > 0)
                {
                    return highQueue.Dequeue();
                }
                else if (aboveQueue.Count > 0)
                {
                    return aboveQueue.Dequeue();
                }
                else if (normalQueue.Count > 0)
                {
                    return normalQueue.Dequeue();
                }
                else if (belowQueue.Count > 0)
                {
                    return belowQueue.Dequeue();
                }
                else
                    return lowQueue.Dequeue();
            }
        }
    }
}
