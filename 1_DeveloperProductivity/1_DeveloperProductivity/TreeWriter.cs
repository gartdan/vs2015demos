using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperProductivity
{
    public class TreeWriter<T> where T : IComparable
    {
        public void Write(Tree<T> tree, string path)
        {
            var stream = new FileStream(path, FileMode.OpenOrCreate);
            var bytes = Encoding.UTF8.GetBytes(tree.ToString());
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
