//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'payment_type.g.dart';

class PaymentType extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Cash')
  static const PaymentType cash = _$cash;
  @BuiltValueEnumConst(wireName: r'CreditCard')
  static const PaymentType creditCard = _$creditCard;
  @BuiltValueEnumConst(wireName: r'Ticket')
  static const PaymentType ticket = _$ticket;
  @BuiltValueEnumConst(wireName: r'Sodexo')
  static const PaymentType sodexo = _$sodexo;
  @BuiltValueEnumConst(wireName: r'Multinet')
  static const PaymentType multinet = _$multinet;

  static Serializer<PaymentType> get serializer => _$paymentTypeSerializer;

  const PaymentType._(String name): super(name);

  static BuiltSet<PaymentType> get values => _$values;
  static PaymentType valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class PaymentTypeMixin = Object with _$PaymentTypeMixin;

