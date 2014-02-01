using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class LibraryException : ApplicationException
    {
        public LibraryException(string message)
            : base(message)
        {
        }

        public class UnknownException : LibraryException
        {
            public UnknownException(string message)
                : base(message)
            {
            }
        }

        #region User Exceptions

        public class InvalidUserNameException : LibraryException
        {
            public InvalidUserNameException(string message)
                : base(message)
            {
            }
        }

        public class NonExistingUserException : LibraryException
        {
            public NonExistingUserException(string message)
                : base(message)
            {
            }
        }

        public class UserExistException : LibraryException
        {
            public UserExistException(string message)
                : base(message)
            {
            }
        }

        #endregion

        #region Media Exceptions

        public class NonExistingMediaException : LibraryException
        {
            public NonExistingMediaException(string message)
                : base(message)
            {
            }
        }

        public class MediaExistException : LibraryException
        {
            public MediaExistException(string message)
                : base(message)
            {
            }
        }

        public class NonRentableMediaException : LibraryException
        {
            public NonRentableMediaException(string message)
                : base(message)
            {
            }
        }

        public class NonBuyableMediaException : LibraryException
        {
            public NonBuyableMediaException(string message)
                : base(message)
            {
            }
        }

        public class NonReadableMediaException : LibraryException
        {
            public NonReadableMediaException(string message)
                : base(message)
            {
            }
        }

        public class WrongMediaTypeSlectionException : LibraryException
        {
            public WrongMediaTypeSlectionException(string message)
                : base(message)
            {
            }
        }


        #endregion

        #region IOExceptions

        public class NonImplementedInterfaceException : LibraryException
        {
            public NonImplementedInterfaceException(string message)
                : base(message)
            {
            }
        }


        #endregion
    }


}
