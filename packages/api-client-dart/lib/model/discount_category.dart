//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'discount_category.g.dart';

class DiscountCategory extends EnumClass {

  @BuiltValueEnumConst(wireName: r'All')
  static const DiscountCategory all = _$all;
  @BuiltValueEnumConst(wireName: r'Branch')
  static const DiscountCategory branch = _$branch;
  @BuiltValueEnumConst(wireName: r'Personnel')
  static const DiscountCategory personnel = _$personnel;
  @BuiltValueEnumConst(wireName: r'Pos')
  static const DiscountCategory pos = _$pos;

  static Serializer<DiscountCategory> get serializer => _$discountCategorySerializer;

  const DiscountCategory._(String name): super(name);

  static BuiltSet<DiscountCategory> get values => _$values;
  static DiscountCategory valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class DiscountCategoryMixin = Object with _$DiscountCategoryMixin;

