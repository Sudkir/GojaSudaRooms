using System;

namespace GojaSudaRooms.Helper
{
    public class ClassUserId
    {
        private ClassUserId()
        {
        }

        private static readonly Lazy<ClassUserId> instance = new Lazy<ClassUserId>(() => new ClassUserId());
        public static ClassUserId Instance { get { return instance.Value; } }

        public int USER { get; set; }
        public int numOrder { get; set; }
    }
}