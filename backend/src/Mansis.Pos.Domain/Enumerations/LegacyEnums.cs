namespace Mansis.Pos.Domain.Enumerations;

public enum AddressType { Home, Office, Dorm }
public enum AssignmentTableType { Pos, Branch, Store }
public enum BalanceMovementType { Order, BalanceLoading, CanceledOrder }
public enum DiscountCategory { All, Branch, Personnel, Pos }
public enum DiscountType { Percentage, Amount }
public enum LogActivityType { Update, Delete }
public enum MailType { GeneratePassword, ResetPassword, Report }
public enum MoneyUnitType { TL, USD, EUR }
public enum OrderState { Received, Preparing, Completed, Cancelled, Deleted, Transferring }
public enum PaymentType { Cash, CreditCard, Ticket, Sodexo, Multinet }
public enum PermissionType { Undefined = 0 }
public enum ProductTransferState { Requested, Confirmed, Received, Cancelled }
public enum ProductType { Store, Pos }
public enum ProductUnitType { Adet, MiliLitre, Gram }
public enum ShippingType { Self, ComeTake, Order, Customer }
public enum StoreProductMovementType { StockIn, StockOut, Destroy, Order, Purchase, TransferIn, TransferOut }
public enum TaxType { Sifir, Bir, Sekiz, OnSekiz }
public enum LedgerDirection { Debit, Credit }
public enum LedgerEntryState { Posted, Reversed }
public enum OrderPaymentState { Pending, Captured, Cancelled, Refunded }
public enum PaymentSummary { Cash, CreditCard, Ticket, Sodexo, Multinet, Mixed }
public enum TokenState { Active, Used, Revoked, Expired }
public enum LoyaltyPointTransactionType { Earn, Redeem, Expire, Adjust, Reverse }
public enum RewardRedemptionState { Requested, Approved, Cancelled, Completed }
public enum EarnRuleScope { All, Branch, Category }
public enum RewardType { DiscountAmount, FreeProduct, Custom }
public enum CampaignType { ExtraPoints, DiscountAmount, Stamp }
