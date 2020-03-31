using System;
using System.Collections.Generic;
using System.Text;

namespace KEANet.Services.Interfaces
{
    public interface IPurchaseService
    {
        //        Including/excluding the Internet connection boolean The new total price
        //Incrementing the number of phone lines N/A The new total price
        //Decrementing the number of phone lines N/A The new total price
        //Selecting a cell phone string: model name The new total price
        //Unselecting a cell phone string: model name The new total price
        //Buying N/A The string to be shown in the alert

        int AddInternetConnection(bool internetConnection);
        int AddPhoneLines();
        int RemovePhoneLines();
        int SelectPhone(string modelName);
        int UnSelectPhone(string modelName);
        string Buy();

    }
}
