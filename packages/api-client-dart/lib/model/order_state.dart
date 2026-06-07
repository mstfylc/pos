//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'order_state.g.dart';

class OrderState extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Received')
  static const OrderState received = _$received;
  @BuiltValueEnumConst(wireName: r'Preparing')
  static const OrderState preparing = _$preparing;
  @BuiltValueEnumConst(wireName: r'Completed')
  static const OrderState completed = _$completed;
  @BuiltValueEnumConst(wireName: r'Cancelled')
  static const OrderState cancelled = _$cancelled;
  @BuiltValueEnumConst(wireName: r'Deleted')
  static const OrderState deleted = _$deleted;
  @BuiltValueEnumConst(wireName: r'Transferring')
  static const OrderState transferring = _$transferring;

  static Serializer<OrderState> get serializer => _$orderStateSerializer;

  const OrderState._(String name): super(name);

  static BuiltSet<OrderState> get values => _$values;
  static OrderState valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class OrderStateMixin = Object with _$OrderStateMixin;

