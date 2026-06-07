//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/available_reward_dto.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'loyalty_preview_response.g.dart';

abstract class LoyaltyPreviewResponse implements Built<LoyaltyPreviewResponse, LoyaltyPreviewResponseBuilder> {

    @BuiltValueField(wireName: r'grossTotal')
    double get grossTotal;

    @BuiltValueField(wireName: r'campaignDiscount')
    double get campaignDiscount;

    @BuiltValueField(wireName: r'finalTotal')
    double get finalTotal;

    @BuiltValueField(wireName: r'earnPoints')
    int get earnPoints;

    @nullable
    @BuiltValueField(wireName: r'earnExpiresAt')
    DateTime get earnExpiresAt;

    @BuiltValueField(wireName: r'campaignExtraPoints')
    int get campaignExtraPoints;

    @BuiltValueField(wireName: r'appliedCampaigns')
    BuiltList<String> get appliedCampaigns;

    @BuiltValueField(wireName: r'availableRewards')
    BuiltList<AvailableRewardDto> get availableRewards;

    LoyaltyPreviewResponse._();

    static void _initializeBuilder(LoyaltyPreviewResponseBuilder b) => b;

    factory LoyaltyPreviewResponse([void updates(LoyaltyPreviewResponseBuilder b)]) = _$LoyaltyPreviewResponse;

    @BuiltValueSerializer(custom: true)
    static Serializer<LoyaltyPreviewResponse> get serializer => _$LoyaltyPreviewResponseSerializer();
}

class _$LoyaltyPreviewResponseSerializer implements StructuredSerializer<LoyaltyPreviewResponse> {

    @override
    final Iterable<Type> types = const [LoyaltyPreviewResponse, _$LoyaltyPreviewResponse];
    @override
    final String wireName = r'LoyaltyPreviewResponse';

    @override
    Iterable<Object> serialize(Serializers serializers, LoyaltyPreviewResponse object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'grossTotal')
            ..add(serializers.serialize(object.grossTotal,
                specifiedType: const FullType(double)));
        result
            ..add(r'campaignDiscount')
            ..add(serializers.serialize(object.campaignDiscount,
                specifiedType: const FullType(double)));
        result
            ..add(r'finalTotal')
            ..add(serializers.serialize(object.finalTotal,
                specifiedType: const FullType(double)));
        result
            ..add(r'earnPoints')
            ..add(serializers.serialize(object.earnPoints,
                specifiedType: const FullType(int)));
        result
            ..add(r'earnExpiresAt')
            ..add(object.earnExpiresAt == null ? null : serializers.serialize(object.earnExpiresAt,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'campaignExtraPoints')
            ..add(serializers.serialize(object.campaignExtraPoints,
                specifiedType: const FullType(int)));
        result
            ..add(r'appliedCampaigns')
            ..add(serializers.serialize(object.appliedCampaigns,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        result
            ..add(r'availableRewards')
            ..add(serializers.serialize(object.availableRewards,
                specifiedType: const FullType(BuiltList, [FullType(AvailableRewardDto)])));
        return result;
    }

    @override
    LoyaltyPreviewResponse deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = LoyaltyPreviewResponseBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'grossTotal':
                    result.grossTotal = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'campaignDiscount':
                    result.campaignDiscount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'finalTotal':
                    result.finalTotal = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'earnPoints':
                    result.earnPoints = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'earnExpiresAt':
                    result.earnExpiresAt = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'campaignExtraPoints':
                    result.campaignExtraPoints = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'appliedCampaigns':
                    result.appliedCampaigns.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
                case r'availableRewards':
                    result.availableRewards.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(AvailableRewardDto)])) as BuiltList<AvailableRewardDto>);
                    break;
            }
        }
        return result.build();
    }
}

