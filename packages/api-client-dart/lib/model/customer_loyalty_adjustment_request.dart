//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'customer_loyalty_adjustment_request.g.dart';

abstract class CustomerLoyaltyAdjustmentRequest implements Built<CustomerLoyaltyAdjustmentRequest, CustomerLoyaltyAdjustmentRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'points')
    int get points;

    @BuiltValueField(wireName: r'direction')
    int get direction;

    @BuiltValueField(wireName: r'reason')
    String get reason;

    CustomerLoyaltyAdjustmentRequest._();

    static void _initializeBuilder(CustomerLoyaltyAdjustmentRequestBuilder b) => b;

    factory CustomerLoyaltyAdjustmentRequest([void updates(CustomerLoyaltyAdjustmentRequestBuilder b)]) = _$CustomerLoyaltyAdjustmentRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<CustomerLoyaltyAdjustmentRequest> get serializer => _$CustomerLoyaltyAdjustmentRequestSerializer();
}

class _$CustomerLoyaltyAdjustmentRequestSerializer implements StructuredSerializer<CustomerLoyaltyAdjustmentRequest> {

    @override
    final Iterable<Type> types = const [CustomerLoyaltyAdjustmentRequest, _$CustomerLoyaltyAdjustmentRequest];
    @override
    final String wireName = r'CustomerLoyaltyAdjustmentRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, CustomerLoyaltyAdjustmentRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'points')
            ..add(serializers.serialize(object.points,
                specifiedType: const FullType(int)));
        result
            ..add(r'direction')
            ..add(serializers.serialize(object.direction,
                specifiedType: const FullType(int)));
        result
            ..add(r'reason')
            ..add(serializers.serialize(object.reason,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    CustomerLoyaltyAdjustmentRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CustomerLoyaltyAdjustmentRequestBuilder();

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
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'points':
                    result.points = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'direction':
                    result.direction = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'reason':
                    result.reason = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

