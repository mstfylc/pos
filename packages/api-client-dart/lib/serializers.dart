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

import 'package:mansis_pos_api_client/model/address_dto.dart';
import 'package:mansis_pos_api_client/model/address_write_dto.dart';
import 'package:mansis_pos_api_client/model/assignment_dto.dart';
import 'package:mansis_pos_api_client/model/assignment_record_dto.dart';
import 'package:mansis_pos_api_client/model/assignment_write_dto.dart';
import 'package:mansis_pos_api_client/model/auth_token_result.dart';
import 'package:mansis_pos_api_client/model/available_reward_dto.dart';
import 'package:mansis_pos_api_client/model/campaign_dto.dart';
import 'package:mansis_pos_api_client/model/campaign_write_dto.dart';
import 'package:mansis_pos_api_client/model/cancel_order_response.dart';
import 'package:mansis_pos_api_client/model/cancel_transfer_request.dart';
import 'package:mansis_pos_api_client/model/category_dto.dart';
import 'package:mansis_pos_api_client/model/category_write_dto.dart';
import 'package:mansis_pos_api_client/model/confirm_transfer_request.dart';
import 'package:mansis_pos_api_client/model/create_app_order_discount_request.dart';
import 'package:mansis_pos_api_client/model/create_app_order_line_request.dart';
import 'package:mansis_pos_api_client/model/create_app_order_payment_request.dart';
import 'package:mansis_pos_api_client/model/create_app_order_request.dart';
import 'package:mansis_pos_api_client/model/create_transfer_request.dart';
import 'package:mansis_pos_api_client/model/customer_card_token_response.dart';
import 'package:mansis_pos_api_client/model/customer_detail_dto.dart';
import 'package:mansis_pos_api_client/model/customer_dto.dart';
import 'package:mansis_pos_api_client/model/customer_loyalty_adjustment_request.dart';
import 'package:mansis_pos_api_client/model/customer_wallet_adjustment_request.dart';
import 'package:mansis_pos_api_client/model/customer_write_dto.dart';
import 'package:mansis_pos_api_client/model/destroy_stock_request.dart';
import 'package:mansis_pos_api_client/model/discount_dto.dart';
import 'package:mansis_pos_api_client/model/discount_write_dto.dart';
import 'package:mansis_pos_api_client/model/earn_rule_dto.dart';
import 'package:mansis_pos_api_client/model/earn_rule_write_dto.dart';
import 'package:mansis_pos_api_client/model/entry_product_delivery_report_row.dart';
import 'package:mansis_pos_api_client/model/identified_customer_dto.dart';
import 'package:mansis_pos_api_client/model/identify_customer_request.dart';
import 'package:mansis_pos_api_client/model/issue_customer_card_token_api_request.dart';
import 'package:mansis_pos_api_client/model/login_request.dart';
import 'package:mansis_pos_api_client/model/loyalty_account_dto.dart';
import 'package:mansis_pos_api_client/model/loyalty_adjustment_dto.dart';
import 'package:mansis_pos_api_client/model/loyalty_preview_line.dart';
import 'package:mansis_pos_api_client/model/loyalty_preview_request.dart';
import 'package:mansis_pos_api_client/model/loyalty_preview_response.dart';
import 'package:mansis_pos_api_client/model/loyalty_tier_dto.dart';
import 'package:mansis_pos_api_client/model/loyalty_tier_write_dto.dart';
import 'package:mansis_pos_api_client/model/order_list_dto.dart';
import 'package:mansis_pos_api_client/model/order_response.dart';
import 'package:mansis_pos_api_client/model/otp_request.dart';
import 'package:mansis_pos_api_client/model/otp_result.dart';
import 'package:mansis_pos_api_client/model/otp_verify_request.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_campaign_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_customer_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_discount_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_earn_rule_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_loyalty_tier_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_order_list_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_product_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_purchase_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_reward_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_stamp_card_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_stock_movement_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_supplier_dto.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_user_dto.dart';
import 'package:mansis_pos_api_client/model/permission_dto.dart';
import 'package:mansis_pos_api_client/model/pos_dto.dart';
import 'package:mansis_pos_api_client/model/pos_product_catalog_response.dart';
import 'package:mansis_pos_api_client/model/pos_product_category_dto.dart';
import 'package:mansis_pos_api_client/model/pos_product_dto.dart';
import 'package:mansis_pos_api_client/model/pos_product_sale_dto.dart';
import 'package:mansis_pos_api_client/model/pos_product_write_dto.dart';
import 'package:mansis_pos_api_client/model/pos_write_dto.dart';
import 'package:mansis_pos_api_client/model/problem_details.dart';
import 'package:mansis_pos_api_client/model/product_dto.dart';
import 'package:mansis_pos_api_client/model/product_write_dto.dart';
import 'package:mansis_pos_api_client/model/purchase_dto.dart';
import 'package:mansis_pos_api_client/model/purchase_line_dto.dart';
import 'package:mansis_pos_api_client/model/purchase_line_write_dto.dart';
import 'package:mansis_pos_api_client/model/purchase_write_dto.dart';
import 'package:mansis_pos_api_client/model/reason_request.dart';
import 'package:mansis_pos_api_client/model/receive_transfer_line_dto.dart';
import 'package:mansis_pos_api_client/model/receive_transfer_request.dart';
import 'package:mansis_pos_api_client/model/redeem_reward_api_request.dart';
import 'package:mansis_pos_api_client/model/redeem_reward_response.dart';
import 'package:mansis_pos_api_client/model/refresh_token_request.dart';
import 'package:mansis_pos_api_client/model/reward_dto.dart';
import 'package:mansis_pos_api_client/model/reward_write_dto.dart';
import 'package:mansis_pos_api_client/model/role_dto.dart';
import 'package:mansis_pos_api_client/model/role_permission_write_dto.dart';
import 'package:mansis_pos_api_client/model/role_write_dto.dart';
import 'package:mansis_pos_api_client/model/stamp_card_dto.dart';
import 'package:mansis_pos_api_client/model/stamp_card_write_dto.dart';
import 'package:mansis_pos_api_client/model/stock_adjustment_request.dart';
import 'package:mansis_pos_api_client/model/stock_count_request.dart';
import 'package:mansis_pos_api_client/model/stock_movement_dto.dart';
import 'package:mansis_pos_api_client/model/store_dto.dart';
import 'package:mansis_pos_api_client/model/store_product_transfer_dto.dart';
import 'package:mansis_pos_api_client/model/store_product_transfer_line_dto.dart';
import 'package:mansis_pos_api_client/model/store_write_dto.dart';
import 'package:mansis_pos_api_client/model/supplier_dto.dart';
import 'package:mansis_pos_api_client/model/supplier_write_dto.dart';
import 'package:mansis_pos_api_client/model/transfer_line_write_dto.dart';
import 'package:mansis_pos_api_client/model/user_dto.dart';
import 'package:mansis_pos_api_client/model/user_write_dto.dart';
import 'package:mansis_pos_api_client/model/wallet_account_dto.dart';
import 'package:mansis_pos_api_client/model/wallet_adjustment_dto.dart';

part 'serializers.g.dart';

@SerializersFor(const [
  AddressDto,
  AddressWriteDto,
  AssignmentDto,
  AssignmentRecordDto,
  AssignmentWriteDto,
  AuthTokenResult,
  AvailableRewardDto,
  CampaignDto,
  CampaignWriteDto,
  CancelOrderResponse,
  CancelTransferRequest,
  CategoryDto,
  CategoryWriteDto,
  ConfirmTransferRequest,
  CreateAppOrderDiscountRequest,
  CreateAppOrderLineRequest,
  CreateAppOrderPaymentRequest,
  CreateAppOrderRequest,
  CreateTransferRequest,
  CustomerCardTokenResponse,
  CustomerDetailDto,
  CustomerDto,
  CustomerLoyaltyAdjustmentRequest,
  CustomerWalletAdjustmentRequest,
  CustomerWriteDto,
  DestroyStockRequest,
  DiscountDto,
  DiscountWriteDto,
  EarnRuleDto,
  EarnRuleWriteDto,
  EntryProductDeliveryReportRow,
  IdentifiedCustomerDto,
  IdentifyCustomerRequest,
  IssueCustomerCardTokenApiRequest,
  LoginRequest,
  LoyaltyAccountDto,
  LoyaltyAdjustmentDto,
  LoyaltyPreviewLine,
  LoyaltyPreviewRequest,
  LoyaltyPreviewResponse,
  LoyaltyTierDto,
  LoyaltyTierWriteDto,
  OrderListDto,
  OrderResponse,
  OtpRequest,
  OtpResult,
  OtpVerifyRequest,
  PagedResultOfCampaignDto,
  PagedResultOfCustomerDto,
  PagedResultOfDiscountDto,
  PagedResultOfEarnRuleDto,
  PagedResultOfLoyaltyTierDto,
  PagedResultOfOrderListDto,
  PagedResultOfProductDto,
  PagedResultOfPurchaseDto,
  PagedResultOfRewardDto,
  PagedResultOfStampCardDto,
  PagedResultOfStockMovementDto,
  PagedResultOfSupplierDto,
  PagedResultOfUserDto,
  PermissionDto,
  PosDto,
  PosProductCatalogResponse,
  PosProductCategoryDto,
  PosProductDto,
  PosProductSaleDto,
  PosProductWriteDto,
  PosWriteDto,
  ProblemDetails,
  ProductDto,
  ProductWriteDto,
  PurchaseDto,
  PurchaseLineDto,
  PurchaseLineWriteDto,
  PurchaseWriteDto,
  ReasonRequest,
  ReceiveTransferLineDto,
  ReceiveTransferRequest,
  RedeemRewardApiRequest,
  RedeemRewardResponse,
  RefreshTokenRequest,
  RewardDto,
  RewardWriteDto,
  RoleDto,
  RolePermissionWriteDto,
  RoleWriteDto,
  StampCardDto,
  StampCardWriteDto,
  StockAdjustmentRequest,
  StockCountRequest,
  StockMovementDto,
  StoreDto,
  StoreProductTransferDto,
  StoreProductTransferLineDto,
  StoreWriteDto,
  SupplierDto,
  SupplierWriteDto,
  TransferLineWriteDto,
  UserDto,
  UserWriteDto,
  WalletAccountDto,
  WalletAdjustmentDto,
])
Serializers serializers = (_$serializers.toBuilder()
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(PermissionDto)]),
        () => ListBuilder<PermissionDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(PosProductDto)]),
        () => ListBuilder<PosProductDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(StoreDto)]),
        () => ListBuilder<StoreDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(AssignmentDto)]),
        () => ListBuilder<AssignmentDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(PosDto)]),
        () => ListBuilder<PosDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(CategoryDto)]),
        () => ListBuilder<CategoryDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(RoleDto)]),
        () => ListBuilder<RoleDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(CustomerDto)]),
        () => ListBuilder<CustomerDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(DiscountDto)]),
        () => ListBuilder<DiscountDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(StoreDto)]),
        () => ListBuilder<StoreDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(OrderListDto)]),
        () => ListBuilder<OrderListDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(ProductDto)]),
        () => ListBuilder<ProductDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(PosDto)]),
        () => ListBuilder<PosDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(CategoryDto)]),
        () => ListBuilder<CategoryDto>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(EntryProductDeliveryReportRow)]),
        () => ListBuilder<EntryProductDeliveryReportRow>(),
      )
      ..add(Iso8601DateTimeSerializer()))
    .build();

Serializers standardSerializers =
    (serializers.toBuilder()..addPlugin(StandardJsonPlugin())).build();
