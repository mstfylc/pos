//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'store_product_movement_type.g.dart';

class StoreProductMovementType extends EnumClass {

  @BuiltValueEnumConst(wireName: r'StockIn')
  static const StoreProductMovementType stockIn = _$stockIn;
  @BuiltValueEnumConst(wireName: r'StockOut')
  static const StoreProductMovementType stockOut = _$stockOut;
  @BuiltValueEnumConst(wireName: r'Destroy')
  static const StoreProductMovementType destroy = _$destroy;
  @BuiltValueEnumConst(wireName: r'Order')
  static const StoreProductMovementType order = _$order;
  @BuiltValueEnumConst(wireName: r'Purchase')
  static const StoreProductMovementType purchase = _$purchase;
  @BuiltValueEnumConst(wireName: r'TransferIn')
  static const StoreProductMovementType transferIn = _$transferIn;
  @BuiltValueEnumConst(wireName: r'TransferOut')
  static const StoreProductMovementType transferOut = _$transferOut;

  static Serializer<StoreProductMovementType> get serializer => _$storeProductMovementTypeSerializer;

  const StoreProductMovementType._(String name): super(name);

  static BuiltSet<StoreProductMovementType> get values => _$values;
  static StoreProductMovementType valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class StoreProductMovementTypeMixin = Object with _$StoreProductMovementTypeMixin;

