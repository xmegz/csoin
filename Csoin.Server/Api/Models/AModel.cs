using Csoin.Server.Models.Interfaces;

namespace Csoin.Server.Api
{
    public abstract class AModel : IGetKey
    {
        public abstract string GetKey();

    }
}
