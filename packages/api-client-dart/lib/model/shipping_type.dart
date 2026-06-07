//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'shipping_type.g.dart';

class ShippingType extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Self')
  static const ShippingType self = _$self;
  @BuiltValueEnumConst(wireName: r'ComeTake')
  static const ShippingType comeTake = _$comeTake;
  @BuiltValueEnumConst(wireName: r'Order')
  static const ShippingType order = _$order;
  @BuiltValueEnumConst(wireName: r'Customer')
  static const ShippingType customer = _$customer;

  static Serializer<ShippingType> get serializer => _$shippingTypeSerializer;

  const ShippingType._(String name): super(name);

  static BuiltSet<ShippingType> get values => _$values;
  static ShippingType valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class ShippingTypeMixin = Object with _$ShippingTypeMixin;

