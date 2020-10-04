using System;
using System.Collections.Generic;
using System.Text;

namespace StrongMuscle.Models {
    class SingletonContext {
        private static Context _context;
        public static Context GetInstance() {
            if (_context == null) {
                _context = new Context();
            }
            return _context;
        }
    }
}
