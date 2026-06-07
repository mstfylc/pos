//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'create_app_order_discount_request.g.dart';

abstract class CreateAppOrderDiscountRequest implements Built<CreateAppOrderDiscountRequest, CreateAppOrderDiscountRequestBuilder> {

    @BuiltValueField(wireName: r'discountId')
    String get discountId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'amount')
    double get amount;

    CreateAppOrderDiscountRequest._();

    static void _initializeBuilder(CreateAppOrderDiscountRequestBuilder b) => b;

    factory CreateAppOrderDiscountRequest([void updates(CreateAppOrderDiscountRequestBuilder b)]) = _$CreateAppOrderDiscountRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<CreateAppOrderDiscountRequest> get serializer => _$CreateAppOrderDiscountRequestSerializer();
}

class _$CreateAppOrderDiscountRequestSerializer implements StructuredSerializer<CreateAppOrderDiscountRequest> {

    @override
    final Iterable<Type> types = const [CreateAppOrderDiscountRequest, _$CreateAppOrderDiscountRequest];
    @override
    final String wireName = r'CreateAppOrderDiscountRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, CreateAppOrderDiscountRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'discountId')
            ..add(serializers.serialize(object.discountId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'amount')
            ..add(serializers.serialize(object.amount,
                specifiedType: const FullType(double)));
        return result;
    }

    @override
    CreateAppOrderDiscountRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CreateAppOrderDiscountRequestBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'discountId':
                    result.discountId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'amount':
                    result.amount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
            }
        }
        return result.build();
    }
}

