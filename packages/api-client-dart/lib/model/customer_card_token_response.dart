//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'customer_card_token_response.g.dart';

abstract class CustomerCardTokenResponse implements Built<CustomerCardTokenResponse, CustomerCardTokenResponseBuilder> {

    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @BuiltValueField(wireName: r'token')
    String get token;

    @BuiltValueField(wireName: r'expiresAt')
    DateTime get expiresAt;

    CustomerCardTokenResponse._();

    static void _initializeBuilder(CustomerCardTokenResponseBuilder b) => b;

    factory CustomerCardTokenResponse([void updates(CustomerCardTokenResponseBuilder b)]) = _$CustomerCardTokenResponse;

    @BuiltValueSerializer(custom: true)
    static Serializer<CustomerCardTokenResponse> get serializer => _$CustomerCardTokenResponseSerializer();
}

class _$CustomerCardTokenResponseSerializer implements StructuredSerializer<CustomerCardTokenResponse> {

    @override
    final Iterable<Type> types = const [CustomerCardTokenResponse, _$CustomerCardTokenResponse];
    @override
    final String wireName = r'CustomerCardTokenResponse';

    @override
    Iterable<Object> serialize(Serializers serializers, CustomerCardTokenResponse object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'customerId')
            ..add(serializers.serialize(object.customerId,
                specifiedType: const FullType(String)));
        result
            ..add(r'token')
            ..add(serializers.serialize(object.token,
                specifiedType: const FullType(String)));
        result
            ..add(r'expiresAt')
            ..add(serializers.serialize(object.expiresAt,
                specifiedType: const FullType(DateTime)));
        return result;
    }

    @override
    CustomerCardTokenResponse deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CustomerCardTokenResponseBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'token':
                    result.token = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'expiresAt':
                    result.expiresAt = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
            }
        }
        return result.build();
    }
}

