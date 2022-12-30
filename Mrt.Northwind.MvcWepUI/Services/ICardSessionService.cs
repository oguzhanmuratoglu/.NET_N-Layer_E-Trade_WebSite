using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.MvcWepUI.Services
{
    public interface ICardSessionService
    {
        void SetCard(Card card);
        Card GetCard();
    }
}
