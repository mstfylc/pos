//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'stamp_card_write_dto.g.dart';

abstract class StampCardWriteDto implements Built<StampCardWriteDto, StampCardWriteDtoBuilder> {

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

    StampCardWriteDto._();

    static void _initializeBuilder(StampCardWriteDtoBuilder b) => b;

    factory StampCardWriteDto([void updates(StampCardWriteDtoBuilder b)]) = _$StampCardWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<StampCardWriteDto> get serializer => _$StampCardWriteDtoSerializer();
}

class _$StampCardWriteDtoSerializer implements StructuredSerializer<StampCardWriteDto> {

    @override
    final Iterable<Type> types = const [StampCardWriteDto, _$StampCardWriteDto];
    @override
    final String wireName = r'StampCardWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, StampCardWriteDto object,
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
        result
            ..add(r'rewardId')
            ..add(object.rewardId == null ? null : serializers.serialize(object.rewardId,
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
    StampCardWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = StampCardWriteDtoBuilder();

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

