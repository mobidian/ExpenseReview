﻿using System;
using System.IO;

namespace ReimbursementApp.Model
{
   [Flags()]
    public enum TicketState
    {

        //Approval --> This is for offline, 
        //Submitted --> Pending for approval, Next-->AdminCheck-->FinanceCheck Status (Processed,Pending with reason)
        //Need to create two flows for admin and Bills
        Submitted = 1,

        Pending = 2, //either from admin, finance, manager, reason also required

        Approved = 3

    }
}