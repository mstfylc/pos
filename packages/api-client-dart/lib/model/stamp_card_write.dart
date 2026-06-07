//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'stamp_card_write.g.dart';

abstract class StampCardWrite implements Built<StampCardWrite, StampCardWriteBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'requiredStamps')
    int get requiredStamps;

    @nullable
    @BuiltValueField(wireName: r'rewardId')
    String get rewardId;

    @nullable
    @BuiltValueField(wireName: r'startsAt')
    DateTime get startsAt;

    @nullable
    @BuiltValueField(wireName: r'endsAt')
    DateTime get endsAt;

    @BuiltValueField(wireName: r'active')
    bool get active;

    StampCardWrite._();

    static void _initializeBuilder(StampCardWriteBuilder b) => b;

    factory StampCardWrite([void updates(StampCardWriteBuilder b)]) = _$StampCardWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<StampCardWrite> get serializer => _$StampCardWriteSerializer();
}

class _$StampCardWriteSerializer implements StructuredSerializer<StampCardWrite> {

    @override
    final Iterable<Type> types = const [StampCardWrite, _$StampCardWrite];
    @override
    final String wireName = r'StampCardWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, StampCardWrite object,
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
            ..add(r'requiredStamps')
            ..add(serializers.serialize(object.requiredStamps,
                specifiedType: const FullType(int)));
        if (object.rewardId != null) {
            result
                ..add(r'rewardId')
                ..add(serializers.serialize(object.rewardId,
                    specifiedType: const FullType(String)));
        }
        if (object.startsAt != null) {
            result
                ..add(r'startsAt')
                ..add(serializers.serialize(object.startsAt,
                    specifiedType: const FullType(DateTime)));
        }
        if (object.endsAt != null) {
            result
                ..add(r'endsAt')
                ..add(serializers.serialize(object.endsAt,
                    specifiedType: const FullType(DateTime)));
        }
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    StampCardWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = StampCardWriteBuilder();

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
                case r'requiredStamps':
                    result.requiredStamps = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'rewardId':
                    result.rewardId = serializers.deserialize(value,
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

