//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'product_transfer_state.g.dart';

class ProductTransferState extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Requested')
  static const ProductTransferState requested = _$requested;
  @BuiltValueEnumConst(wireName: r'Confirmed')
  static const ProductTransferState confirmed = _$confirmed;
  @BuiltValueEnumConst(wireName: r'Received')
  static const ProductTransferState received = _$received;
  @BuiltValueEnumConst(wireName: r'Cancelled')
  static const ProductTransferState cancelled = _$cancelled;

  static Serializer<ProductTransferState> get serializer => _$productTransferStateSerializer;

  const ProductTransferState._(String name): super(name);

  static BuiltSet<ProductTransferState> get values => _$values;
  static ProductTransferState valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class ProductTransferStateMixin = Object with _$ProductTransferStateMixin;

