//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'customer_wallet_adjustment_request.g.dart';

abstract class CustomerWalletAdjustmentRequest implements Built<CustomerWalletAdjustmentRequest, CustomerWalletAdjustmentRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'amount')
    double get amount;

    @BuiltValueField(wireName: r'direction')
    int get direction;

    @BuiltValueField(wireName: r'reason')
    String get reason;

    CustomerWalletAdjustmentRequest._();

    static void _initializeBuilder(CustomerWalletAdjustmentRequestBuilder b) => b;

    factory CustomerWalletAdjustmentRequest([void updates(CustomerWalletAdjustmentRequestBuilder b)]) = _$CustomerWalletAdjustmentRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<CustomerWalletAdjustmentRequest> get serializer => _$CustomerWalletAdjustmentRequestSerializer();
}

class _$CustomerWalletAdjustmentRequestSerializer implements StructuredSerializer<CustomerWalletAdjustmentRequest> {

    @override
    final Iterable<Type> types = const [CustomerWalletAdjustmentRequest, _$CustomerWalletAdjustmentRequest];
    @override
    final String wireName = r'CustomerWalletAdjustmentRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, CustomerWalletAdjustmentRequest object,
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
            ..add(r'amount')
            ..add(serializers.serialize(object.amount,
                specifiedType: const FullType(double)));
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
    CustomerWalletAdjustmentRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CustomerWalletAdjustmentRequestBuilder();

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
                case r'amount':
                    result.amount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
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

