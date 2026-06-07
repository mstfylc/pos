//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'store_write_dto.g.dart';

abstract class StoreWriteDto implements Built<StoreWriteDto, StoreWriteDtoBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @nullable
    @BuiltValueField(wireName: r'branchId')
    String get branchId;

    StoreWriteDto._();

    static void _initializeBuilder(StoreWriteDtoBuilder b) => b;

    factory StoreWriteDto([void updates(StoreWriteDtoBuilder b)]) = _$StoreWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<StoreWriteDto> get serializer => _$StoreWriteDtoSerializer();
}

class _$StoreWriteDtoSerializer implements StructuredSerializer<StoreWriteDto> {

    @override
    final Iterable<Type> types = const [StoreWriteDto, _$StoreWriteDto];
    @override
    final String wireName = r'StoreWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, StoreWriteDto object,
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
            ..add(r'branchId')
            ..add(object.branchId == null ? null : serializers.serialize(object.branchId,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    StoreWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = StoreWriteDtoBuilder();

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
                case r'branchId':
                    result.branchId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

