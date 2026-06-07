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

import 'package:mansis_pos_api_client/model/cancel_order_response.dart';
import 'package:mansis_pos_api_client/model/category.dart';
import 'package:mansis_pos_api_client/model/category_write.dart';
import 'package:mansis_pos_api_client/model/company.dart';
import 'package:mansis_pos_api_client/model/create_order_request.dart';
import 'package:mansis_pos_api_client/model/customer.dart';
import 'package:mansis_pos_api_client/model/customer_write.dart';
import 'package:mansis_pos_api_client/model/discount.dart';
import 'package:mansis_pos_api_client/model/discount_category.dart';
import 'package:mansis_pos_api_client/model/discount_type.dart';
import 'package:mansis_pos_api_client/model/discount_write.dart';
import 'package:mansis_pos_api_client/model/loyalty_account.dart';
import 'package:mansis_pos_api_client/model/order.dart';
import 'package:mansis_pos_api_client/model/order_line.dart';
import 'package:mansis_pos_api_client/model/order_list_item.dart';
import 'package:mansis_pos_api_client/model/order_payment.dart';
import 'package:mansis_pos_api_client/model/order_response.dart';
import 'package:mansis_pos_api_client/model/order_state.dart';
import 'package:mansis_pos_api_client/model/payment_summary.dart';
import 'package:mansis_pos_api_client/model/payment_type.dart';
import 'package:mansis_pos_api_client/model/pos.dart';
import 'package:mansis_pos_api_client/model/pos_write.dart';
import 'package:mansis_pos_api_client/model/problem_details.dart';
import 'package:mansis_pos_api_client/model/product.dart';
import 'package:mansis_pos_api_client/model/product_unit_type.dart';
import 'package:mansis_pos_api_client/model/product_write.dart';
import 'package:mansis_pos_api_client/model/reason_request.dart';
import 'package:mansis_pos_api_client/model/shipping_type.dart';
import 'package:mansis_pos_api_client/model/stock_movement.dart';
import 'package:mansis_pos_api_client/model/store.dart';
import 'package:mansis_pos_api_client/model/store_product_movement_type.dart';
import 'package:mansis_pos_api_client/model/store_write.dart';
import 'package:mansis_pos_api_client/model/tax_type.dart';
import 'package:mansis_pos_api_client/model/wallet_account.dart';

part 'serializers.g.dart';

@SerializersFor(const [
  CancelOrderResponse,
  Category,
  CategoryWrite,
  Company,
  CreateOrderRequest,
  Customer,
  CustomerWrite,
  Discount,
  DiscountCategory,
  DiscountType,
  DiscountWrite,
  LoyaltyAccount,
  Order,
  OrderLine,
  OrderListItem,
  OrderPayment,
  OrderResponse,
  OrderState,
  PaymentSummary,
  PaymentType,
  Pos,
  PosWrite,
  ProblemDetails,
  Product,
  ProductUnitType,
  ProductWrite,
  ReasonRequest,
  ShippingType,
  StockMovement,
  Store,
  StoreProductMovementType,
  StoreWrite,
  TaxType,
  WalletAccount,
])
Serializers serializers = (_$serializers.toBuilder()
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Company)]),
        () => ListBuilder<Company>(),
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
        const FullType(BuiltList, [FullType(StockMovement)]),
        () => ListBuilder<StockMovement>(),
      )
      ..add(Iso8601DateTimeSerializer()))
    .build();

Serializers standardSerializers =
    (serializers.toBuilder()..addPlugin(StandardJsonPlugin())).build();
