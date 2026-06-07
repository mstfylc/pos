//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

library serializers;

import 'package:built_value/iso_8601_date_time_serializer.dart';
import 'package:built_value/serializer.dart';
import 'package:built_collection/built_collection.dart';
import 'package:built_value/json_object.dart';
import 'package:built_value/standard_json_plugin.dart';

import 'package:mansis_pos_api_client/model/assignment.dart';
import 'package:mansis_pos_api_client/model/assignment_record.dart';
import 'package:mansis_pos_api_client/model/assignment_table_type.dart';
import 'package:mansis_pos_api_client/model/assignment_write.dart';
import 'package:mansis_pos_api_client/model/auth_token_result.dart';
import 'package:mansis_pos_api_client/model/available_reward.dart';
import 'package:mansis_pos_api_client/model/campaign.dart';
import 'package:mansis_pos_api_client/model/campaign_type.dart';
import 'package:mansis_pos_api_client/model/campaign_write.dart';
import 'package:mansis_pos_api_client/model/cancel_order_response.dart';
import 'package:mansis_pos_api_client/model/cancel_transfer_request.dart';
import 'package:mansis_pos_api_client/model/category.dart';
import 'package:mansis_pos_api_client/model/category_write.dart';
import 'package:mansis_pos_api_client/model/company.dart';
import 'package:mansis_pos_api_client/model/confirm_transfer_request.dart';
import 'package:mansis_pos_api_client/model/create_order_request.dart';
import 'package:mansis_pos_api_client/model/create_transfer_request.dart';
import 'package:mansis_pos_api_client/model/customer.dart';
import 'package:mansis_pos_api_client/model/customer_card_token_response.dart';
import 'package:mansis_pos_api_client/model/customer_write.dart';
import 'package:mansis_pos_api_client/model/destroy_stock_request.dart';
import 'package:mansis_pos_api_client/model/discount.dart';
import 'package:mansis_pos_api_client/model/discount_category.dart';
import 'package:mansis_pos_api_client/model/discount_type.dart';
import 'package:mansis_pos_api_client/model/discount_write.dart';
import 'package:mansis_pos_api_client/model/earn_rule.dart';
import 'package:mansis_pos_api_client/model/earn_rule_scope.dart';
import 'package:mansis_pos_api_client/model/earn_rule_write.dart';
import 'package:mansis_pos_api_client/model/entry_product_delivery_report_row.dart';
import 'package:mansis_pos_api_client/model/entry_tracking_mode.dart';
import 'package:mansis_pos_api_client/model/identified_customer.dart';
import 'package:mansis_pos_api_client/model/identify_customer_request.dart';
import 'package:mansis_pos_api_client/model/issue_customer_card_token_request.dart';
import 'package:mansis_pos_api_client/model/ledger_direction.dart';
import 'package:mansis_pos_api_client/model/ledger_entry_state.dart';
import 'package:mansis_pos_api_client/model/login_request.dart';
import 'package:mansis_pos_api_client/model/loyalty_account.dart';
import 'package:mansis_pos_api_client/model/loyalty_preview_line.dart';
import 'package:mansis_pos_api_client/model/loyalty_preview_request.dart';
import 'package:mansis_pos_api_client/model/loyalty_preview_response.dart';
import 'package:mansis_pos_api_client/model/loyalty_tier.dart';
import 'package:mansis_pos_api_client/model/loyalty_tier_write.dart';
import 'package:mansis_pos_api_client/model/order.dart';
import 'package:mansis_pos_api_client/model/order_discount_write.dart';
import 'package:mansis_pos_api_client/model/order_line.dart';
import 'package:mansis_pos_api_client/model/order_list_item.dart';
import 'package:mansis_pos_api_client/model/order_payment.dart';
import 'package:mansis_pos_api_client/model/order_response.dart';
import 'package:mansis_pos_api_client/model/order_state.dart';
import 'package:mansis_pos_api_client/model/otp_request.dart';
import 'package:mansis_pos_api_client/model/otp_result.dart';
import 'package:mansis_pos_api_client/model/otp_verify_request.dart';
import 'package:mansis_pos_api_client/model/payment_summary.dart';
import 'package:mansis_pos_api_client/model/payment_type.dart';
import 'package:mansis_pos_api_client/model/permission.dart';
import 'package:mansis_pos_api_client/model/permission_type.dart';
import 'package:mansis_pos_api_client/model/pos.dart';
import 'package:mansis_pos_api_client/model/pos_product.dart';
import 'package:mansis_pos_api_client/model/pos_product_catalog_response.dart';
import 'package:mansis_pos_api_client/model/pos_product_category.dart';
import 'package:mansis_pos_api_client/model/pos_product_sale.dart';
import 'package:mansis_pos_api_client/model/pos_product_write.dart';
import 'package:mansis_pos_api_client/model/pos_write.dart';
import 'package:mansis_pos_api_client/model/problem_details.dart';
import 'package:mansis_pos_api_client/model/product.dart';
import 'package:mansis_pos_api_client/model/product_transfer_state.dart';
import 'package:mansis_pos_api_client/model/product_unit_type.dart';
import 'package:mansis_pos_api_client/model/product_write.dart';
import 'package:mansis_pos_api_client/model/reason_request.dart';
import 'package:mansis_pos_api_client/model/receive_transfer_line.dart';
import 'package:mansis_pos_api_client/model/receive_transfer_request.dart';
import 'package:mansis_pos_api_client/model/refresh_token_request.dart';
import 'package:mansis_pos_api_client/model/reward.dart';
import 'package:mansis_pos_api_client/model/reward_type.dart';
import 'package:mansis_pos_api_client/model/reward_write.dart';
import 'package:mansis_pos_api_client/model/role.dart';
import 'package:mansis_pos_api_client/model/role_permission_write.dart';
import 'package:mansis_pos_api_client/model/role_write.dart';
import 'package:mansis_pos_api_client/model/shipping_type.dart';
import 'package:mansis_pos_api_client/model/stamp_card.dart';
import 'package:mansis_pos_api_client/model/stamp_card_write.dart';
import 'package:mansis_pos_api_client/model/stock_adjustment_request.dart';
import 'package:mansis_pos_api_client/model/stock_count_request.dart';
import 'package:mansis_pos_api_client/model/stock_movement.dart';
import 'package:mansis_pos_api_client/model/store.dart';
import 'package:mansis_pos_api_client/model/store_product_movement_type.dart';
import 'package:mansis_pos_api_client/model/store_product_transfer.dart';
import 'package:mansis_pos_api_client/model/store_product_transfer_line.dart';
import 'package:mansis_pos_api_client/model/store_write.dart';
import 'package:mansis_pos_api_client/model/tax_type.dart';
import 'package:mansis_pos_api_client/model/transfer_line_write.dart';
import 'package:mansis_pos_api_client/model/user.dart';
import 'package:mansis_pos_api_client/model/user_write.dart';
import 'package:mansis_pos_api_client/model/wallet_account.dart';

part 'serializers.g.dart';

@SerializersFor(const [
  Assignment,
  AssignmentRecord,
  AssignmentTableType,
  AssignmentWrite,
  AuthTokenResult,
  AvailableReward,
  Campaign,
  CampaignType,
  CampaignWrite,
  CancelOrderResponse,
  CancelTransferRequest,
  Category,
  CategoryWrite,
  Company,
  ConfirmTransferRequest,
  CreateOrderRequest,
  CreateTransferRequest,
  Customer,
  CustomerCardTokenResponse,
  CustomerWrite,
  DestroyStockRequest,
  Discount,
  DiscountCategory,
  DiscountType,
  DiscountWrite,
  EarnRule,
  EarnRuleScope,
  EarnRuleWrite,
  EntryProductDeliveryReportRow,
  EntryTrackingMode,
  IdentifiedCustomer,
  IdentifyCustomerRequest,
  IssueCustomerCardTokenRequest,
  LedgerDirection,
  LedgerEntryState,
  LoginRequest,
  LoyaltyAccount,
  LoyaltyPreviewLine,
  LoyaltyPreviewRequest,
  LoyaltyPreviewResponse,
  LoyaltyTier,
  LoyaltyTierWrite,
  Order,
  OrderDiscountWrite,
  OrderLine,
  OrderListItem,
  OrderPayment,
  OrderResponse,
  OrderState,
  OtpRequest,
  OtpResult,
  OtpVerifyRequest,
  PaymentSummary,
  PaymentType,
  Permission,
  PermissionType,
  Pos,
  PosProduct,
  PosProductCatalogResponse,
  PosProductCategory,
  PosProductSale,
  PosProductWrite,
  PosWrite,
  ProblemDetails,
  Product,
  ProductTransferState,
  ProductUnitType,
  ProductWrite,
  ReasonRequest,
  ReceiveTransferLine,
  ReceiveTransferRequest,
  RefreshTokenRequest,
  Reward,
  RewardType,
  RewardWrite,
  Role,
  RolePermissionWrite,
  RoleWrite,
  ShippingType,
  StampCard,
  StampCardWrite,
  StockAdjustmentRequest,
  StockCountRequest,
  StockMovement,
  Store,
  StoreProductMovementType,
  StoreProductTransfer,
  StoreProductTransferLine,
  StoreWrite,
  TaxType,
  TransferLineWrite,
  User,
  UserWrite,
  WalletAccount,
])
Serializers serializers = (_$serializers.toBuilder()
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Assignment)]),
        () => ListBuilder<Assignment>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Product)]),
        () => ListBuilder<Product>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Campaign)]),
        () => ListBuilder<Campaign>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Pos)]),
        () => ListBuilder<Pos>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Company)]),
        () => ListBuilder<Company>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(OrderListItem)]),
        () => ListBuilder<OrderListItem>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Role)]),
        () => ListBuilder<Role>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Category)]),
        () => ListBuilder<Category>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(User)]),
        () => ListBuilder<User>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Permission)]),
        () => ListBuilder<Permission>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(EarnRule)]),
        () => ListBuilder<EarnRule>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Discount)]),
        () => ListBuilder<Discount>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Customer)]),
        () => ListBuilder<Customer>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(StampCard)]),
        () => ListBuilder<StampCard>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(LoyaltyTier)]),
        () => ListBuilder<LoyaltyTier>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Store)]),
        () => ListBuilder<Store>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Reward)]),
        () => ListBuilder<Reward>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(OrderListItem)]),
        () => ListBuilder<OrderListItem>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Category)]),
        () => ListBuilder<Category>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Product)]),
        () => ListBuilder<Product>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Discount)]),
        () => ListBuilder<Discount>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Customer)]),
        () => ListBuilder<Customer>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Store)]),
        () => ListBuilder<Store>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Pos)]),
        () => ListBuilder<Pos>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(EntryProductDeliveryReportRow)]),
        () => ListBuilder<EntryProductDeliveryReportRow>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(StockMovement)]),
        () => ListBuilder<StockMovement>(),
      )
      ..add(Iso8601DateTimeSerializer()))
    .build();

Serializers standardSerializers =
    (serializers.toBuilder()..addPlugin(StandardJsonPlugin())).build();
