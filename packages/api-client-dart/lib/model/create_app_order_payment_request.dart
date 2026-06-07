//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'create_app_order_payment_request.g.dart';

abstract class CreateAppOrderPaymentRequest implements Built<CreateAppOrderPaymentRequest, CreateAppOrderPaymentRequestBuilder> {

    @BuiltValueField(wireName: r'paymentType')
    int get paymentType;

    @BuiltValueField(wireName: r'amount')
    double get amount;

    @BuiltValueField(wireName: r'currency')
    String get currency;

    @nullable
    @BuiltValueField(wireName: r'externalReference')
    String get externalReference;

    CreateAppOrderPaymentRequest._();

    static void _initializeBuilder(CreateAppOrderPaymentRequestBuilder b) => b
        ..currency = 'TRY';

    factory CreateAppOrderPaymentRequest([void updates(CreateAppOrderPaymentRequestBuilder b)]) = _$CreateAppOrderPaymentRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<CreateAppOrderPaymentRequest> get serializer => _$CreateAppOrderPaymentRequestSerializer();
}

class _$CreateAppOrderPaymentRequestSerializer implements StructuredSerializer<CreateAppOrderPaymentRequest> {

    @override
    final Iterable<Type> types = const [CreateAppOrderPaymentRequest, _$CreateAppOrderPaymentRequest];
    @override
    final String wireName = r'CreateAppOrderPaymentRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, CreateAppOrderPaymentRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'paymentType')
            ..add(serializers.serialize(object.paymentType,
                specifiedType: const FullType(int)));
        result
            ..add(r'amount')
            ..add(serializers.serialize(object.amount,
                specifiedType: const FullType(double)));
        if (object.currency != null) {
            result
                ..add(r'currency')
                ..add(serializers.serialize(object.currency,
                    specifiedType: const FullType(String)));
        }
        if (object.externalReference != null) {
            result
                ..add(r'externalReference')
                ..add(serializers.serialize(object.externalReference,
                    specifiedType: const FullType(String)));
        }
        return result;
    }

    @override
    CreateAppOrderPaymentRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CreateAppOrderPaymentRequestBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'paymentType':
                    result.paymentType = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'amount':
                    result.amount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'currency':
                    result.currency = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'externalReference':
                    result.externalReference = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

