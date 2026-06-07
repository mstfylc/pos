//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'earn_rule_dto.g.dart';

abstract class EarnRuleDto implements Built<EarnRuleDto, EarnRuleDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'pointsPerCurrency')
    double get pointsPerCurrency;

    @BuiltValueField(wireName: r'minOrder')
    double get minOrder;

    @nullable
    @BuiltValueField(wireName: r'expiryDays')
    int get expiryDays;

    @BuiltValueField(wireName: r'scope')
    int get scope;

    @nullable
    @BuiltValueField(wireName: r'branchId')
    String get branchId;

    @nullable
    @BuiltValueField(wireName: r'categoryId')
    String get categoryId;

    @nullable
    @BuiltValueField(wireName: r'startsAt')
    DateTime get startsAt;

    @nullable
    @BuiltValueField(wireName: r'endsAt')
    DateTime get endsAt;

    @BuiltValueField(wireName: r'active')
    bool get active;

    EarnRuleDto._();

    static void _initializeBuilder(EarnRuleDtoBuilder b) => b;

    factory EarnRuleDto([void updates(EarnRuleDtoBuilder b)]) = _$EarnRuleDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<EarnRuleDto> get serializer => _$EarnRuleDtoSerializer();
}

class _$EarnRuleDtoSerializer implements StructuredSerializer<EarnRuleDto> {

    @override
    final Iterable<Type> types = const [EarnRuleDto, _$EarnRuleDto];
    @override
    final String wireName = r'EarnRuleDto';

    @override
    Iterable<Object> serialize(Serializers serializers, EarnRuleDto object,
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
            ..add(r'pointsPerCurrency')
            ..add(serializers.serialize(object.pointsPerCurrency,
                specifiedType: const FullType(double)));
        result
            ..add(r'minOrder')
            ..add(serializers.serialize(object.minOrder,
                specifiedType: const FullType(double)));
        result
            ..add(r'expiryDays')
            ..add(object.expiryDays == null ? null : serializers.serialize(object.expiryDays,
                specifiedType: const FullType(int)));
        result
            ..add(r'scope')
            ..add(serializers.serialize(object.scope,
                specifiedType: const FullType(int)));
        result
            ..add(r'branchId')
            ..add(object.branchId == null ? null : serializers.serialize(object.branchId,
                specifiedType: const FullType(String)));
        result
            ..add(r'categoryId')
            ..add(object.categoryId == null ? null : serializers.serialize(object.categoryId,
                specifiedType: const FullType(String)));
        result
            ..add(r'startsAt')
            ..add(object.startsAt == null ? null : serializers.serialize(object.startsAt,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'endsAt')
            ..add(object.endsAt == null ? null : serializers.serialize(object.endsAt,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    EarnRuleDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = EarnRuleDtoBuilder();

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
                case r'pointsPerCurrency':
                    result.pointsPerCurrency = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'minOrder':
                    result.minOrder = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'expiryDays':
                    result.expiryDays = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'scope':
                    result.scope = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'branchId':
                    result.branchId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'categoryId':
                    result.categoryId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'startsAt':
                    result.startsAt = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'endsAt':
                    result.endsAt = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
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

