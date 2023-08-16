using BtkAkademi.Services.ShoppingCartAPI.Models.DTO;

namespace BtkAkademi.Services.ShoppingCartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
