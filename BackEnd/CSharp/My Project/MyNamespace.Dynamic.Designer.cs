using System;
using System.ComponentModel;
using System.Diagnostics;

namespace WebApp.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Client m_Client;

            public Client Client
            {
                [DebuggerHidden]
                get
                {
                    m_Client = Create__Instance__(m_Client);
                    return m_Client;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Client))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Client);
                }
            }
        }
    }
}