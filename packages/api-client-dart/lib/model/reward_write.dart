//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/reward_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'reward_write.g.dart';

abstract class RewardWrite implements Built<RewardWrite, RewardWriteBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'pointCost')
    int get pointCost;

    @BuiltValueField(wireName: r'rewardType')
    RewardType get rewardType;
    // enum rewardTypeEnum {  DiscountAmount,  FreeProduct,  Custom,  };

    @nullable
    @BuiltValueField(wireName: r'discountAmount')
    double get discountAmount;

    @nullable
    @BuiltValueField(wireName: r'image')
    String get image;

    @nullable
    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'active')
    bool get active;

    RewardWrite._();

    static void _initializeBuilder(RewardWriteBuilder b) => b;

    factory RewardWrite([void updates(RewardWriteBuilder b)]) = _$RewardWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<RewardWrite> get serializer => _$RewardWriteSerializer();
}

class _$RewardWriteSerializer implements StructuredSerializer<RewardWrite> {

    @override
    final Iterable<Type> types = const [RewardWrite, _$RewardWrite];
    @override
    final String wireName = r'RewardWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, RewardWrite object,
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
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'pointCost')
            ..add(serializers.serialize(object.pointCost,
                specifiedType: const FullType(int)));
        result
            ..add(r'rewardType')
            ..add(serializers.serialize(object.rewardType,
                specifiedType: const FullType(RewardType)));
        if (object.discountAmount != null) {
            result
                ..add(r'discountAmount')
                ..add(serializers.serialize(object.discountAmount,
                    specifiedType: const FullType(double)));
        }
        if (object.image != null) {
            result
                ..add(r'image')
                ..add(serializers.serialize(object.image,
                    specifiedType: const FullType(String)));
        }
        if (object.productId != null) {
            result
                ..add(r'productId')
                ..add(serializers.serialize(object.productId,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    RewardWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = RewardWriteBuilder();

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
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'pointCost':
                    result.pointCost = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'rewardType':
                    result.rewardType = serializers.deserialize(value,
                        specifiedType: const FullType(RewardType)) as RewardType;
                    break;
                case r'discountAmount':
                    result.discountAmount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'image':
                    result.image = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'active':
                    result.active = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

