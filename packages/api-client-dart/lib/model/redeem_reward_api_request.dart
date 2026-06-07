//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'redeem_reward_api_request.g.dart';

abstract class RedeemRewardApiRequest implements Built<RedeemRewardApiRequest, RedeemRewardApiRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @nullable
    @BuiltValueField(wireName: r'orderId')
    String get orderId;

    RedeemRewardApiRequest._();

    static void _initializeBuilder(RedeemRewardApiRequestBuilder b) => b;

    factory RedeemRewardApiRequest([void updates(RedeemRewardApiRequestBuilder b)]) = _$RedeemRewardApiRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<RedeemRewardApiRequest> get serializer => _$RedeemRewardApiRequestSerializer();
}

class _$RedeemRewardApiRequestSerializer implements StructuredSerializer<RedeemRewardApiRequest> {

    @override
    final Iterable<Type> types = const [RedeemRewardApiRequest, _$RedeemRewardApiRequest];
    @override
    final String wireName = r'RedeemRewardApiRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, RedeemRewardApiRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'customerId')
            ..add(serializers.serialize(object.customerId,
                specifiedType: const FullType(String)));
        result
            ..add(r'orderId')
            ..add(object.orderId == null ? null : serializers.serialize(object.orderId,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    RedeemRewardApiRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = RedeemRewardApiRequestBuilder();

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
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'orderId':
                    result.orderId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

