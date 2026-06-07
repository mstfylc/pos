//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'product_unit_type.g.dart';

class ProductUnitType extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Adet')
  static const ProductUnitType adet = _$adet;
  @BuiltValueEnumConst(wireName: r'MiliLitre')
  static const ProductUnitType miliLitre = _$miliLitre;
  @BuiltValueEnumConst(wireName: r'Gram')
  static const ProductUnitType gram = _$gram;

  static Serializer<ProductUnitType> get serializer => _$productUnitTypeSerializer;

  const ProductUnitType._(String name): super(name);

  static BuiltSet<ProductUnitType> get values => _$values;
  static ProductUnitType valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class ProductUnitTypeMixin = Object with _$ProductUnitTypeMixin;

