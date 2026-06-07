//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'loyalty_tier_dto.g.dart';

abstract class LoyaltyTierDto implements Built<LoyaltyTierDto, LoyaltyTierDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'minPoints')
    int get minPoints;

    @BuiltValueField(wireName: r'pointMultiplier')
    double get pointMultiplier;

    @nullable
    @BuiltValueField(wireName: r'benefits')
    String get benefits;

    @BuiltValueField(wireName: r'active')
    bool get active;

    LoyaltyTierDto._();

    static void _initializeBuilder(LoyaltyTierDtoBuilder b) => b;

    factory LoyaltyTierDto([void updates(LoyaltyTierDtoBuilder b)]) = _$LoyaltyTierDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<LoyaltyTierDto> get serializer => _$LoyaltyTierDtoSerializer();
}

class _$LoyaltyTierDtoSerializer implements StructuredSerializer<LoyaltyTierDto> {

    @override
    final Iterable<Type> types = const [LoyaltyTierDto, _$LoyaltyTierDto];
    @override
    final String wireName = r'LoyaltyTierDto';

    @override
    Iterable<Object> serialize(Serializers serializers, LoyaltyTierDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'minPoints')
            ..add(serializers.serialize(object.minPoints,
                specifiedType: const FullType(int)));
        result
            ..add(r'pointMultiplier')
            ..add(serializers.serialize(object.pointMultiplier,
                specifiedType: const FullType(double)));
        result
            ..add(r'benefits')
            ..add(object.benefits == null ? null : serializers.serialize(object.benefits,
                specifiedType: const FullType(String)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    LoyaltyTierDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = LoyaltyTierDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'minPoints':
                    result.minPoints = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'pointMultiplier':
                    result.pointMultiplier = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'benefits':
                    result.benefits = serializers.deserialize(value,
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

