//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'loyalty_tier_write.g.dart';

abstract class LoyaltyTierWrite implements Built<LoyaltyTierWrite, LoyaltyTierWriteBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

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

    LoyaltyTierWrite._();

    static void _initializeBuilder(LoyaltyTierWriteBuilder b) => b;

    factory LoyaltyTierWrite([void updates(LoyaltyTierWriteBuilder b)]) = _$LoyaltyTierWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<LoyaltyTierWrite> get serializer => _$LoyaltyTierWriteSerializer();
}

class _$LoyaltyTierWriteSerializer implements StructuredSerializer<LoyaltyTierWrite> {

    @override
    final Iterable<Type> types = const [LoyaltyTierWrite, _$LoyaltyTierWrite];
    @override
    final String wireName = r'LoyaltyTierWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, LoyaltyTierWrite object,
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
            ..add(r'minPoints')
            ..add(serializers.serialize(object.minPoints,
                specifiedType: const FullType(int)));
        result
            ..add(r'pointMultiplier')
            ..add(serializers.serialize(object.pointMultiplier,
                specifiedType: const FullType(double)));
        if (object.benefits != null) {
            result
                ..add(r'benefits')
                ..add(serializers.serialize(object.benefits,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    LoyaltyTierWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = LoyaltyTierWriteBuilder();

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

