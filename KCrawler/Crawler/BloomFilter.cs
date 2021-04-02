using System;
using System.Collections;

namespace KCrawler
{
    [Serializable]
    public class SimpleBloomFilter
    {
        private readonly static int DEFAULT_SIZE = 2 << 24;
        private readonly static int[] seeds = new int[] { 5, 7, 11, 13, 31, 37, 61 };
        private BitArray bits = new BitArray(DEFAULT_SIZE);

        private SimpleHash[] func = new SimpleHash[seeds.Length];

 
        public SimpleBloomFilter()
        {
            for (int i = 0; i < seeds.Length; i++)
            {
                func[i] = new SimpleHash(DEFAULT_SIZE, seeds[i]);
            }
        }

        public void Add(String value)
        {
            lock (bits.SyncRoot)
            {
                foreach (SimpleHash f in func)
                {
                    bits.Set(f.hash(value), true);
                }
            }
        }

        public bool Contains(String value)
        {

            lock (bits.SyncRoot)
            {
                if (value == null)
                    return false;

                if (String.IsNullOrEmpty(value) || value == "")
                    return true;

                bool ret = true;
                foreach (SimpleHash f in func)
                {
                    ret = ret && bits[f.hash(value)];
                }
                return ret;
            }
        }
          [Serializable]
        public class SimpleHash
        {
            private int cap;
            private int seed;

            public SimpleHash(int cap, int seed)
            {
                this.cap = cap;
                this.seed = seed;
            }

            public int hash(String value)
            {
                int result = 0;
                int len = value.Length;
                for (int i = 0; i < len; i++)
                {
                    result = seed * result + value[i];
                }
                return (cap - 1) & result;
            }
        }
    }

}
