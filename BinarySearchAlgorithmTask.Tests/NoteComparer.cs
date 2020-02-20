using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Notebook;

namespace BinarySearchAlgorithmTask.Tests
{
    public class NoteComparer : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            
            return x.CompareTo(y);
        }
    }
}
