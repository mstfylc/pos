//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'payment_summary.g.dart';

class PaymentSummary extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Cash')
  static const PaymentSummary cash = _$cash;
  @BuiltValueEnumConst(wireName: r'CreditCard')
  static const PaymentSummary creditCard = _$creditCard;
  @BuiltValueEnumConst(wireName: r'Ticket')
  static const PaymentSummary ticket = _$ticket;
  @BuiltValueEnumConst(wireName: r'Sodexo')
  static const PaymentSummary sodexo = _$sodexo;
  @BuiltValueEnumConst(wireName: r'Multinet')
  static const PaymentSummary multinet = _$multinet;
  @BuiltValueEnumConst(wireName: r'Mixed')
  static const PaymentSummary mixed = _$mixed;

  static Serializer<PaymentSummary> get serializer => _$paymentSummarySerializer;

  const PaymentSummary._(String name): super(name);

  static BuiltSet<PaymentSummary> get values => _$values;
  static PaymentSummary valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class PaymentSummaryMixin = Object with _$PaymentSummaryMixin;

