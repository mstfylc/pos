//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'tax_type.g.dart';

class TaxType extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Bir')
  static const TaxType bir = _$bir;
  @BuiltValueEnumConst(wireName: r'Sekiz')
  static const TaxType sekiz = _$sekiz;
  @BuiltValueEnumConst(wireName: r'OnSekiz')
  static const TaxType onSekiz = _$onSekiz;

  static Serializer<TaxType> get serializer => _$taxTypeSerializer;

  const TaxType._(String name): super(name);

  static BuiltSet<TaxType> get values => _$values;
  static TaxType valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class TaxTypeMixin = Object with _$TaxTypeMixin;

