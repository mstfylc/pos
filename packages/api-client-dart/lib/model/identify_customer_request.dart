//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'identify_customer_request.g.dart';

abstract class IdentifyCustomerRequest implements Built<IdentifyCustomerRequest, IdentifyCustomerRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @nullable
    @BuiltValueField(wireName: r'token')
    String get token;

    @nullable
    @BuiltValueField(wireName: r'cardNumber')
    String get cardNumber;

    IdentifyCustomerRequest._();

    static void _initializeBuilder(IdentifyCustomerRequestBuilder b) => b;

    factory IdentifyCustomerRequest([void updates(IdentifyCustomerRequestBuilder b)]) = _$IdentifyCustomerRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<IdentifyCustomerRequest> get serializer => _$IdentifyCustomerRequestSerializer();
}

class _$IdentifyCustomerRequestSerializer implements StructuredSerializer<IdentifyCustomerRequest> {

    @override
    final Iterable<Type> types = const [IdentifyCustomerRequest, _$IdentifyCustomerRequest];
    @override
    final String wireName = r'IdentifyCustomerRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, IdentifyCustomerRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'token')
            ..add(object.token == null ? null : serializers.serialize(object.token,
                specifiedType: const FullType(String)));
        result
            ..add(r'cardNumber')
            ..add(object.cardNumber == null ? null : serializers.serialize(object.cardNumber,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    IdentifyCustomerRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = IdentifyCustomerRequestBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'token':
                    result.token = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'cardNumber':
                    result.cardNumber = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

